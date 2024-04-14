using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class OrderModel: BaseModel<Order_, OrderModel>
    {
        public int userId { get; set; }
        public int paymentMethodId { get; set; }
        public string note { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public List<SubOrderModel> subOrders { get; set; }
    }

    public class SubOrderModel : BaseModel<SubOrder, SubOrderModel>
    {
        public int addressId { get; set; }
        public int deliveryMethodId { get; set; }
        public List<SubOrderDetailModel> subOrderDetails { get; set; }
    }

}
