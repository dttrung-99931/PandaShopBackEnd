using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class CreateOrdersModel
    {
        public int paymentMethodId { get; set; }
        public List<OrderModel> orders { get; set; }

        public List<int> productOptionIds
        {
            get
            {
                return orders.SelectMany(
                    (order) => order.OrderDetails.Select((detail) => detail.productOptionId)).ToList();
            }
        }
    }

    public class OrderModel: BaseModel<Order, OrderModel>
    {
        public int addressId { get; set; }
        public int deliveryMethodId { get; set; }
        public string note { get; set; }
        public List<OrderDetailModel> OrderDetails { get; set; }
    }

    public class OrderDetailModel : BaseModel<OrderDetail, OrderDetailModel>
    {
        public DateTime? createdAt { get; set; }
        public int productNum { get; set; }
        public int productOptionId { get; set; }
    }

}
