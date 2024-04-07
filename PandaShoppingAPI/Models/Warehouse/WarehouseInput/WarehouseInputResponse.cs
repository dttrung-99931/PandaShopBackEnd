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
    public class WarehouseInputResponse : BaseModel<WarehouseInput, WarehouseInputResponse>
    {
        public int WarehouseInputId { get; set; }
        public DateTime date { get; set; }
        [JsonProperty("productBatches")]
        public List<ProductBatchResponse> ProductBatch { get; set; }
    }
}