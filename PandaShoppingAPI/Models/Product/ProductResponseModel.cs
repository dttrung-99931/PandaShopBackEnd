using AutoMapper;
using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class ProductResponseModel : BaseModel<Product, ProductResponseModel>
    {
        public string name { get; set; }
        public double starNum { get; set; }
        public string description { get; set; }
        public int sellingNum { get; set; }
        public int remainingNum { get; set; }
        public int categoryId { get; set; }
        public int shopId { get; set; }
    }
}
