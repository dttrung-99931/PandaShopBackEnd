using AutoMapper;
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
    public class ProductResponse : BaseModel<Product, ProductResponse>
    {
        public string name { get; set; }
        public double starNum { get; set; }
        public string description { get; set; }
        public int sellingNum { get; set; }
        public int remainingNum { get; set; }
        public int categoryId { get; set; }
        public int shopId { get; set; }
        
        [JsonProperty("propertyValues")]
        public List<ProductPropertyResponse> ProductPropertyValue { get; set; }
        
        [JsonProperty("options")]
        public List<ProductOptionResponse> ProductOption { get; set; }
        
        protected override void CustomMapping(IMappingExpression<Product, ProductResponse> mappingExpression, IConfiguration config)
        {
            base.CustomMapping(mappingExpression, config);
        }
    }


}
