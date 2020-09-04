using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class ProductModel: BaseModel<Product, ProductModel>
    {
        public string name { get; set; }
        public string description { get; set; }
        public int sellingNum { get; set; }
        public int categoryId { get; set; }
        public int shopId { get; set; }

    }
}
