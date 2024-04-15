using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Models.Order;
using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class OrderService : BaseService<IOrderRepo, Order_, OrderModel, OrderFilter>, 
        IOrderService
    {
        private readonly ISubOrderRepo _subOrderRepo;
        private readonly ISubOrderRepo _subOrderdetailRepo;
        private readonly IProductBatchInventoryRepo _productBatchInvRepo;
        private readonly IWarehouseOutputRepo _warehouseOutputRepo;

        public OrderService(IOrderRepo repo, ISubOrderRepo subOrderRepo, ISubOrderRepo subOrderdetailRepo, IProductBatchInventoryRepo productBatchInvRepo, IWarehouseOutputRepo warehouseOutputRepo) : base(repo)
        {
            _subOrderRepo = subOrderRepo;
            _subOrderdetailRepo = subOrderdetailRepo;
            _productBatchInvRepo = productBatchInvRepo;
            _warehouseOutputRepo = warehouseOutputRepo;
        }

        protected override void ValidateInsert(OrderModel requestModel)
        {
            ValidateAvailableInventory(requestModel);
        }

        public override Order_ Insert(OrderModel requestModel)
        {
            ValidateInsert(requestModel);
            OutputWarehouse(requestModel);
            Order_ order = _repo.Insert(MapInsertEntity(requestModel));
            List<SubOrder> subOrders = requestModel.subOrders.Select((subOrder) =>
                new SubOrder()
                {
                    orderId = order.id,
                    SubOrderDetail = subOrder.subOrderDetails.Select(
                        (detail) => new SubOrderDetail
                        {
                            productOptionId = detail.productOptionId,
                            productNum = detail.productNum,
                            discountPercent = detail.discountPercent,
                            price = detail.price
                        }).ToList(),
                    delivery = new Delivery
                    {
                        addressId = subOrder.addressId,
                        deliveryMethodId = subOrder.deliveryMethodId,
                        state = "created", // TODO: create enum
                    }
                }
            ).ToList();
            _subOrderRepo.InsertRange(subOrders);
            return order;
        }


        private void ValidateAvailableInventory(OrderModel requestModel)
        {
            List<int> productOptionIds = requestModel.subOrders
                .SelectMany((subOrder) => subOrder.subOrderDetails
                    .Select((subDetail) => subDetail.productOptionId)).ToList();
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

            foreach (SubOrderModel subOrder in requestModel.subOrders)
            {
                foreach (SubOrderDetailModel detail in subOrder.subOrderDetails)
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

            List<int> productOptionIds = requestModel.subOrders
                .SelectMany((subOrder) => subOrder.subOrderDetails
                    .Select((subDetail) => subDetail.productOptionId)).ToList();
            List<IGrouping<int, ProductBatchInventory>> optionInvenGroups = _productBatchInvRepo
                .Where((batchInven) => productOptionIds.Contains(batchInven.productBatch.productOptionId) && batchInven.remainingNumber > 0)
                .ToList()
                .GroupBy((batchInven) => batchInven.productBatch.productOptionId)
                .ToList();

            List<WarehouseOutputDetail> outputDetails = new List<WarehouseOutputDetail>();
            List<ProductBatchInventory> updatedBatchInvens = new List<ProductBatchInventory>();

            foreach (SubOrderModel subOrder in requestModel.subOrders)
            {
                foreach (SubOrderDetailModel detail in subOrder.subOrderDetails)
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
