using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using PandaShoppingAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class ProductInventoryResponse
    {
        public ShortProductResponse product { get; set; }
        public List<ProductOptionInvetoryResponse> optionInventories { get; set; }
    }

    public class ProductOptionInvetoryResponse
    {
        public ProductOptionResponse productOption { get; set; }
        public int number { get; set; }
    }
}
