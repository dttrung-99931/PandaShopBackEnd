using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.Models
{
    public class OrderResponseModel: BaseModel<Order_, OrderResponseModel>
    {
        public string note { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        [JsonProperty("subOrders")]
        public List<SubOrderResponse> SubOrder { get; set; }
        public PaymentMethodResponse paymentMethod { get; set; }
    }
}
