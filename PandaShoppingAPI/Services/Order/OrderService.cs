using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public partial class OrderService : BaseService<IOrderRepo, Order, OrderModel, OrderFilter>,
        IOrderService
    {
        private readonly IOrderDetailRepo _orderDetailRepo;
        private readonly IProductBatchInventoryRepo _productBatchInvRepo;
        private readonly IWarehouseOutputRepo _warehouseOutputRepo;
        private readonly ICartDetailRepo _cartDetailRepo;
        private readonly IProductOptionRepo _productOptionRepo;
        private readonly IInvoiceRepo _invoiceRepo;
        private readonly IDeliveryRepo _deliveryRepo;
        private readonly IWarehouseRepo _warehouseRepo;
        private readonly IDeliveryMethodRepo _deliveryMethodRepo;
        private readonly IDeliveryPartnerUnitRepo _deliveryPartnerUnitRepo;
        private readonly IDeliveryLocationRepo _deliveryLocationRepo;
        private readonly IProductRepo _productRepo;

        public OrderService(IOrderRepo repo,
            IOrderDetailRepo orderdetailRepo,
            IProductBatchInventoryRepo productBatchInvRepo,
            IWarehouseOutputRepo warehouseOutputRepo,
            ICartDetailRepo cartDetailRepo,
            IProductOptionRepo productOptionRepo,
            IInvoiceRepo invoiceRepo,
            IDeliveryRepo deliveryRepo,
            IWarehouseRepo warehouseRepo,
            IDeliveryMethodRepo deliveryMethodRepo,
            IDeliveryPartnerUnitRepo deliveryPartnerUnitRepo,
            IDeliveryLocationRepo deliveryLocationRepo,
            IProductRepo productRepo) : base(repo)
        {
            _orderDetailRepo = orderdetailRepo;
            _productBatchInvRepo = productBatchInvRepo;
            _warehouseOutputRepo = warehouseOutputRepo;
            _cartDetailRepo = cartDetailRepo;
            _productOptionRepo = productOptionRepo;
            _invoiceRepo = invoiceRepo;
            _deliveryRepo = deliveryRepo;
            _warehouseRepo = warehouseRepo;
            _deliveryMethodRepo = deliveryMethodRepo;
            _deliveryPartnerUnitRepo = deliveryPartnerUnitRepo;
            _deliveryLocationRepo = deliveryLocationRepo;
            _productRepo = productRepo;
        }

        public override IQueryable<Order> Fill(OrderFilter filter)
        {
            IQueryable<Order> orders = base.Fill(filter);

            orders = FilterByRole(orders);

            if (filter.userId != null)
            {
                orders = orders.Where((order) => order.userId == filter.userId);
            }

            if (filter.shopId != null)
            {
                orders = orders.Where((order) => order.OrderDetail.Any(
                    (detail) => detail.productOption.product.shopId == User.ShopId));
            }

            if (filter.status != null)
            {
                orders = orders.Where((order) => order.status == filter.status);
            }

            return orders.OrderByDescending(order => order.createdAt);
        }

        private IQueryable<Order> FilterByRole(IQueryable<Order> orders)
        {
            if (!User.IsAdmin)
            {
                if (User.IsShop)
                {
                    orders = orders.Where(
                        (order) => order.userId == User.UserId || order.OrderDetail.Any(
                            (detail) => detail.productOption.product.shopId == User.ShopId));

                }
                else
                { // user
                    orders = orders.Where((order) => order.userId == User.UserId);
                }
            }

            return orders;
        }


        public List<Order> Insert(CreateOrdersModel model)
        {
            ValidateAvailableInventory(model.orders);
            Invoice invoice = CreateInvoice(model);
            List<Order> created = CreateOrders(model, invoice.id);
            model.orders.ForEach(OutputWarehouse);
            // Create invoice
            _cartDetailRepo.DeleteCartItems(User.CartId, model.productOptionIds);
            return created;
        }

        private Invoice CreateInvoice(CreateOrdersModel model)
        {
            return _invoiceRepo.Insert(
                new Invoice
                {
                    paymentMethodId = model.paymentMethodId,
                    paymentStatus = PaymentStatus.PayLatter,
                });
        }

        private List<Order> CreateOrders(CreateOrdersModel model, int invoiceId)
        {
            List<Order> orders = model.orders
                .Select((orderModel) => BuildOrder(orderModel, invoiceId))
                .ToList();
            _repo.InsertRange(orders);
            return orders;
        }

        private Order BuildOrder(OrderModel requestModel, int invoiceId)
        {
            // TODO: get shopId from request instaed of query db
            int shopId = _productOptionRepo.GetIQueryable()
                .Where((opt) => opt.id == requestModel.OrderDetails.First().productOptionId)
                .Select(opt => opt.product.shopId)
                .Single();

            Order order = new Order()
            {
                userId = User.UserId,
                invoiceId = invoiceId,
                createdAt = DateTime.UtcNow,
                status = OrderStatus.Created,
                deliveryAddressId = requestModel.addressId,
                deliveryMethodId = requestModel.deliveryMethodId,
                shopId = shopId,
                OrderDetail = requestModel.OrderDetails.Select(
                        (detail) =>
                        {
                            ProductOption productOption = _productOptionRepo.GetById(detail.productOptionId);
                            return new OrderDetail
                            {
                                productOptionId = detail.productOptionId,
                                productNum = detail.productNum,
                                discountPercent = 0,
                                price = productOption.price,
                            };
                        }).ToList(),
            };

            return order;
        }


        private void ValidateAvailableInventory(List<OrderModel> orderModels)
        {
            List<int> productOptionIds = orderModels
                    .SelectMany((order) => order.OrderDetails.Select((detail) => detail.productOptionId))
                    .ToList();
            List<AvailableProductOptionRespone> availableOpotions = _productBatchInvRepo
                .Where((batchInven) => productOptionIds.Contains(batchInven.productBatch.productOptionId))
                .GroupBy((batchInven) => batchInven.productBatch.productOptionId)
                .Select((group) =>
                new
                {
                    productOptionId = group.Key,
                    remainingNumber = group.Sum((batchInven) => batchInven.remainingNumber)
                })
                .ToList()
                .Select((x) => new AvailableProductOptionRespone
                {
                    productOptionId = x.productOptionId,
                    remainingNumber = x.remainingNumber
                })
                .ToList();
            Dictionary<int, int> availableOptionDic = availableOpotions
                .ToDictionary((x) => x.productOptionId, (x) => x.remainingNumber);

            foreach (OrderModel order in orderModels)
            {
                foreach (OrderDetailModel detail in order.OrderDetails)
                {
                    if (!availableOptionDic.ContainsKey(detail.productOptionId) ||
                        availableOptionDic[detail.productOptionId] < detail.productNum)
                    {
                        throw new ConflictException(ErrorCode.notEnoughAvaialableProducts,
                            "Xin lỗi. Số sản phẩm còn lại không đủ số lượng mà bạn mua");
                    }
                }

            }
        }

        private void OutputWarehouse(OrderModel requestModel)
        {

            List<int> productOptionIds = requestModel.OrderDetails
                    .Select((detail) => detail.productOptionId).ToList();
            List<IGrouping<int, ProductBatchInventory>> optionInvenGroups = _productBatchInvRepo
                .Where((batchInven) => productOptionIds.Contains(batchInven.productBatch.productOptionId) && batchInven.remainingNumber > 0)
                .ToList()
                .GroupBy((batchInven) => batchInven.productBatch.productOptionId)
                .ToList();

            List<WarehouseOutputDetail> outputDetails = new List<WarehouseOutputDetail>();
            List<ProductBatchInventory> updatedBatchInvens = new List<ProductBatchInventory>();

            foreach (OrderDetailModel detail in requestModel.OrderDetails)
            {
                IGrouping<int, ProductBatchInventory> group = optionInvenGroups.First(
                    (group) => group.Key == detail.productOptionId);
                List<ProductBatchInventory> batches = group.OrderByDescending(
                    (batch) => batch.productBatch.warehouseInput.date).ToList();
                int outputNum = 0, i = 0;
                while (outputNum < detail.productNum && i < batches.Count)
                {
                    ProductBatchInventory batch = batches[i];
                    int needNumber = detail.productNum - outputNum;
                    int takeFromBatchNum = batch.remainingNumber >= needNumber ? needNumber : batch.remainingNumber;
                    batch.remainingNumber = batch.remainingNumber - takeFromBatchNum;
                    outputNum += takeFromBatchNum;
                    updatedBatchInvens.Add(batch);
                    WarehouseOutputDetail output = new WarehouseOutputDetail
                    {
                        number = takeFromBatchNum,
                        productBatchId = batch.id,
                    };
                    outputDetails.Add(output);
                    i++;
                }
            }

            _warehouseOutputRepo.Insert(new WarehouseOutput
            {
                date = DateTime.UtcNow,
                WarehouseOutputDetail = outputDetails,
            });
            _productBatchInvRepo.UpdateRange(updatedBatchInvens);
        }

        public List<TempDeliveryResponse> GetCompleteProcessingOrders()
        {
            return GetOrderGroupsByStatus(OrderStatus.CompleteProcessing);
        }


        // Return orders group by status. Each group contains maximum [Constants.DELIVERY_ORDER_SIZE] orders
        private List<TempDeliveryResponse> GetOrderGroupsByStatus(OrderStatus status)
        {
            IQueryable<Order> completeProcessingOrders =
                Fill(new OrderFilter { status = status, shopId = User.ShopId, });

            List<IGrouping<DeliveryMethod, Order>> groupsByDeliMethod = completeProcessingOrders
                .ToList() // TODO: Optimize
                .GroupBy(order => order.deliveryMethod)
                .ToList();

            List<TempDeliveryResponse> tempDeliveries = new List<TempDeliveryResponse>();

            // Create temp delivery by take 10 orders from order group of same delivery method
            groupsByDeliMethod
                .ForEach(group =>
                {
                    group.Chunk(Constants.DELIVERY_ORDER_SIZE)
                        .ToList()
                        .ForEach(orders =>
                        {
                            DeliveryPartnerUnit deliPartnerUnit = GetDeliveryPartnerUnit(group.Key, orders.ToList());
                            tempDeliveries.Add(new TempDeliveryResponse
                            {
                                orders = Mapper.Map<List<OrderResponseModel>>(orders),
                                deliveryPartnerUnitAddress = Mapper.Map<AddressModel>(deliPartnerUnit.address),
                                deliveryPartnerUnitId = deliPartnerUnit.id,
                                deliveryMethodId = group.Key.id,
                            });
                        });
                });

            return tempDeliveries;
        }

        private DeliveryPartnerUnit GetDeliveryPartnerUnit(DeliveryMethod method, List<Order> orders)
        {
            // TODO: impl get delivery partner unit based on method & orders
            return _deliveryPartnerUnitRepo.GetIQueryable().First();
        }

        public List<DeliveryWithOrdersResponse>  GetWaitingDeliveryWithOrders()
        {
            return GetDeliveryWithOrders(false);
        }
            

        public List<DeliveryWithOrdersResponse> GetDeliveringDeliveryWithOrders()
        {
            return GetDeliveryWithOrders(true);
        }

        /// Get waitingForDelivering or delivery order groups
        private List<DeliveryWithOrdersResponse> GetDeliveryWithOrders(bool isDelivering)
        {
            int warehouseAddrId = GetDefaultWarehouseAddrId();
            List<Delivery> waitingDeliveries = _deliveryRepo.GetIQueryable()
                .Where((deli) => deli.status == (isDelivering ? DeliveryStatus.Delivering : DeliveryStatus.Created) 
                    && deli.DeliveryLocation.Any(location => location.addressId == warehouseAddrId))
                .ToList();
            return waitingDeliveries.Select(
                delivery =>
                {
                    AddressModel deliPartnerAddress = Mapper.Map<AddressModel>
                    (
                        delivery.DeliveryLocation
                        .Where(location => location.locationType == LocationType.DeliveryPartner)
                        .First().address
                    );
                    return new DeliveryWithOrdersResponse
                    {
                        id = delivery.id,
                        status = delivery.status,
                        progress = Mapper.Map<DeliveryProgressModel>(delivery.deliveryDriver),
                        deliveryPartnerUnitAddress = deliPartnerAddress,
                        orders = delivery.OrderDelivery
                            .Select(orderDeli => Mapper.Map<OrderResponseModel>(orderDeli.order))
                            .ToList()
                    };
                }
            ).ToList();
        }
    }
}
