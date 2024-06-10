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

        public OrderService(IOrderRepo repo,
            IOrderDetailRepo orderdetailRepo,
            IProductBatchInventoryRepo productBatchInvRepo,
            IWarehouseOutputRepo warehouseOutputRepo,
            ICartDetailRepo cartDetailRepo,
            IProductOptionRepo productOptionRepo,
            IInvoiceRepo invoiceRepo) : base(repo)
        {
            _orderDetailRepo = orderdetailRepo;
            _productBatchInvRepo = productBatchInvRepo;
            _warehouseOutputRepo = warehouseOutputRepo;
            _cartDetailRepo = cartDetailRepo;
            _productOptionRepo = productOptionRepo;
            _invoiceRepo = invoiceRepo;
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
            Order order = new Order()
                {
                    userId = User.UserId,
                    invoiceId = invoiceId,
                    createdAt = DateTime.UtcNow,
                    status = OrderStatus.Created,
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
                    delivery = new Delivery
                    {
                        deliveryMethodId = requestModel.deliveryMethodId,
                        status = DeliveryStatus.Created,
                        DeliveryLocation = new List<DeliveryLocation> {
                            new DeliveryLocation {
                                addressId = requestModel.addressId,
                                locationType = LocationType.DeliveryPartner,
                            }
                        }
                    }
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
    }
}
