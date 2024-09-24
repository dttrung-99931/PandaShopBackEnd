using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;

namespace PandaShoppingAPI.Models
{
    public class ShortOrderResponseModel : BaseModel<Order, ShortOrderResponseModel>
    {
        public OrderStatus status { get; set; }
        [JsonProperty("deliveries")]
        public List<ShortDeliveryResponse> Delivery { get; set; }
        [JsonProperty("orderDetails")]
        public virtual List<ShortOrderDetailResponse> OrderDetail { get; set; }
    }


    public class ShortOrderDetailResponse : BaseModel<OrderDetail, ShortOrderDetailResponse>
    {
        public string productOptionName { get; set; }
        public string productName { get; set; }

        protected override void CustomMapping(IMappingExpression<OrderDetail, ShortOrderDetailResponse> mappingExpression, IConfiguration config)
        {
            mappingExpression.ForMember
            (
                (ShortOrderDetailResponse detail) => detail.productName,
                option => option.MapFrom(
                        (OrderDetail entity) => entity.productOption.product.name)
            )
            .ForMember
            (
                (ShortOrderDetailResponse detail) => detail.productOptionName,
                option => option.MapFrom(
                        (OrderDetail entity) => entity.productOption.name)
            );
        }
    }
}

