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
    public class OrderDetailResponse : BaseModel<Order, OrderDetailModel>
    {
        public virtual DeliveryResponse delivery { get; set; }
        [JsonProperty("OrderDetailDetails")]
        public virtual List<OrderDetailDetailResponse> OrderDetailDetail { get; set; }
    }

    public class OrderDetailDetailResponse : BaseModel<OrderDetail, OrderDetailDetailResponse>
    {
        public DateTime? createdAt { get; set; }
        public double? discountPercent { get; set; }
        public decimal price { get; set; }
        public int productNum { get; set; }
        public ProductOptionResponse productOption { get; set; }
        public ShortProductResponse product { get; set; }

        protected override void CustomMapping(IMappingExpression<OrderDetail, OrderDetailDetailResponse> mappingExpression, IConfiguration config)
        {
            mappingExpression.ForMember
            (
                (OrderDetailDetailResponse detail) => detail.product,
                option => option.MapFrom(
                        (OrderDetail entity) => Mapper.Map<ShortProductResponse>(entity.productOption.product)
                )
            );
        }
    }
}

