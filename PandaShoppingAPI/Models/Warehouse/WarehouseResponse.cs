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
    public class WarehouseResponse : BaseModel<Warehouse, WarehouseResponse>
    {
        public string name { get; set; }
        public int shopId { get; set; }
        public AddressResponseModel address { get; set; }
    }
}
