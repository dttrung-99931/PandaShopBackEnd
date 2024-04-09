using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PandaShoppingAPI.Configs;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using PandaShoppingAPI.Utils.ServiceUtils;
using System.Collections.Generic;
using System.Linq;

namespace PandaShoppingAPI.Models
{
    public class ProductOptionResponse : BaseModel<ProductOption, ProductOptionResponse>
    {
        public string name { get; set; }
        public decimal price { get; set; }

        [JsonProperty("propertyValues")]
        public List<OptionPropertyResponse> ProductOptionValue { get; set; }
        public int remainingNum { get; set; }

        protected override void CustomMapping(IMappingExpression<ProductOption, ProductOptionResponse> mappingExpression, IConfiguration config)
        {
            mappingExpression.ForMember
              (
                  optionResponse => optionResponse.remainingNum,
                  option => option.MapFrom(
                  productOption => productOption.ProductBatch.Sum((ProductBatch batch) => batch.ProductBatchInventory.FirstOrDefault().remainingNumber)
                  )
              );
        }
    }
        
}
