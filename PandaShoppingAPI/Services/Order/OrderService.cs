using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
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

        public OrderService(IOrderRepo repo, ISubOrderRepo subOrderRepo, ISubOrderRepo subOrderdetailRepo) : base(repo)
        {
            _subOrderRepo = subOrderRepo;
            _subOrderdetailRepo = subOrderdetailRepo;
        }

        public override Order_ Insert(OrderModel requestModel)
        {
            Order_ order = base.Insert(requestModel);
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
                    }
                }
            ).ToList();
            _subOrderRepo.InsertRange(subOrders);
            return order;
        }
    }
}
