using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.EntityFrameworkCore;
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
    public class DriverResponseModel : BaseModel<Driver, DriverResponseModel>
    {
        public decimal lat { get; set; }
        [JsonProperty("long")]
        public decimal long_ { get; set; }
    }
}
