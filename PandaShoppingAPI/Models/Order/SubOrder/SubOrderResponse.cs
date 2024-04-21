using System;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System.Collections.Generic;
using Newtonsoft.Json;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.Utils.ServiceUtils;
using System.Linq;

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
        public ShortProductResponse product { get; set; }

        protected override void CustomMapping(IMappingExpression<SubOrderDetail, SubOrderDetailResponse> mappingExpression, IConfiguration config)
        {
            mappingExpression.ForMember
            (
                (SubOrderDetailResponse detail) => detail.product,
                option => option.MapFrom(
                        (SubOrderDetail entity) => Mapper.Map<ShortProductResponse>(entity.productOption.product)
                )
            );
        }
    }
}

