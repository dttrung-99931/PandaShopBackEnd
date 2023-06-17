using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class ProductOptionRequest: BaseModel<ProductOption, ProductOptionRequest>
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public List<PropertyValueRequest> properties { get; set; }
    }
}
