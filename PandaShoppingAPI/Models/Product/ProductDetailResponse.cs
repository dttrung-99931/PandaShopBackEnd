using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class ProductDetailResponse : BaseModel<Product, ProductDetailResponse>
    {
        public string name { get; set; }
        public double starNum { get; set; }
        public string description { get; set; }
        public int sellingNum { get; set; }
        public int categoryId { get; set; }
        public CategoryResponse category { get; set; }
        public int shopId { get; set; }
        public int addressId { get; set; }

        [JsonProperty("propertyValues")]
        public List<ProductPropertyResponse> ProductPropertyValue { get; set; }

        [JsonProperty("options")]
        public List<ProductOptionResponse> ProductOption { get; set; }

        [JsonProperty("images")]
        public List<ProductImageResponse> ProductImage { get; set; }

        public List<DeliveryMethodResponse> deliveryMethods { get; set; }

        // TODO: Hanlde when products have diff deliveryPartnerUnitId of same delivery method
        // public List<ProductDeliveryMethodResponse> productDeliveryMethods { get; set; }

        protected override void CustomMapping(IMappingExpression<Product, ProductDetailResponse> mappingExpression, IConfiguration config)
        {
            mappingExpression.ForMember(
                response => response.deliveryMethods,
                action => action.MapFrom(
                    product => product.ProductDeliveryMethod
                    .Select((prodMethod) => Mapper.Map<DeliveryMethodResponse>(prodMethod.deliveryMethod))
                    .ToList()
                    )
                );
        }

    }


}
