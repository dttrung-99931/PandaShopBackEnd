using AutoMapper;
using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class CartDetailResponse : BaseModel<CartDetail, CartDetailResponse>
    {
        public int productNum { get; set; }
        public ProductOptionResponse productOption { get; set; }
        public ShortProductResponse shortProduct { get; set; }
        public ShopResponseModel shop { get; set; }
        public List<DeliveryMethodResponse> deliveryMethods { get; set; }

        protected override void CustomMapping(IMappingExpression<CartDetail, CartDetailResponse> mappingExpression, IConfiguration config)
        {
            mappingExpression.ForMember(
                response => response.shortProduct,
                action => action.MapFrom(
                    entity => Mapper.Map<ShortProductResponse>(entity.productOption.product))
                )
                .ForMember(
                response => response.shop,
                action => action.MapFrom(
                    entity => Mapper.Map<ShopResponseModel>(entity.productOption.product.shop))
                )
                .ForMember(
                response => response.deliveryMethods,
                action => action.MapFrom(
                    entity => Mapper.Map<List<DeliveryMethodResponse>>(
                        entity.productOption.product.ProductDeliveryMethod.Select((x) => x.deliveryMethod))
                    )
                );
        }

    }
}
