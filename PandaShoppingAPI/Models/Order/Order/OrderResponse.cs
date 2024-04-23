using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.Models
{
    public class OrderResponseModel: BaseModel<Order, OrderResponseModel>
    {
        public string note { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public OrderStatus status { get; set; }
        [JsonProperty("OrderDetails")]
        public List<OrderDetailResponse> OrderDetail { get; set; }
        public PaymentMethodResponse paymentMethod { get; set; }
        public UserShortResponseModel user { get; set; }
    }
}
