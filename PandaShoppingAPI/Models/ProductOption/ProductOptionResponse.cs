using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System.Collections.Generic;

namespace PandaShoppingAPI.Models
{
    public class ProductOptionResponse : BaseModel<ProductOption, ProductOptionResponse>
    {
        public string name { get; set; }
        public decimal price { get; set; }

        [JsonProperty("propertyValues")]
        public List<OptionPropertyResponse> ProductOptionValue { get; set; }
    }
}
