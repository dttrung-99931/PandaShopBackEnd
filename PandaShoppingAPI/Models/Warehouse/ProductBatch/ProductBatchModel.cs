using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using PandaShoppingAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class ProductBatchModel : BaseModel<ProductBatch, ProductBatchModel>
    {
        public int productOptionId { get; set; }
        public int warehouseInputId { get; set; }
        public int number { get; set; }
        public DateTime manufactureDate { get; set; }
        public DateTime? expireDate { get; set; }
        public DateTime? arriveDate { get; set; }

    }
}
