using System;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PandaShoppingAPI.Models
{
    public class SubOrderResponse : BaseModel<SubOrder, SubOrderModel>
    {
        public virtual DeliveryResponse delivery { get; set; }
        [JsonProperty("subOrderDetails")]
        public virtual List<SubOrderDetailResponse> SubOrderDetail { get; set; }
    }

    public class SubOrderDetailResponse : BaseModel<SubOrderDetail, SubOrderDetailResponse>
    {
        public DateTime? createdAt { get; set; }
        public double? discountPercent { get; set; }
        public decimal price { get; set; }
        public int productNum { get; set; }
        public ProductOptionResponse productOption { get; set; }
    }
}

