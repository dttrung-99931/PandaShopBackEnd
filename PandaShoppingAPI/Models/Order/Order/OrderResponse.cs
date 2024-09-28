using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;

namespace PandaShoppingAPI.Models
{
    public class OrderResponseModel : BaseModel<Order, OrderResponseModel>
    {
        public string note { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public OrderStatus status { get; set; }

        public UserShortResponseModel user { get; set; }
        public AddressResponseModel deliveryAddress { get; set; }
    
        [JsonProperty("deliveries")]
        public List<DeliveryResponse> Delivery { get; set; }

        [JsonProperty("orderDetails")]
        public List<OrderDetailResponse> OrderDetail { get; set; }
    }

    public class OrderDetailResponse : BaseModel<OrderDetail, OrderDetailResponse>
    {
        public double? discountPercent { get; set; }
        public decimal price { get; set; }
        public int productNum { get; set; }
        public ProductOptionResponse productOption { get; set; }
        public ShortProductResponse product { get; set; }

        protected override void CustomMapping(IMappingExpression<OrderDetail, OrderDetailResponse> mappingExpression, IConfiguration config)
        {
            mappingExpression.ForMember
            (
                (OrderDetailResponse detail) => detail.product,
                option => option.MapFrom(
                        (OrderDetail entity) => Mapper.Map<ShortProductResponse>(entity.productOption.product)
                )
            );
        }
    }
}

