
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
    public class WarehouseInputModel : BaseModel<WarehouseInput, WarehouseInputModel>
    {
        public int warehouseId { get; set; }
        public DateTime date { get; set; }
    }
}
