using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class DeliveryResponse : BaseModel<Delivery, DeliveryResponse>
    {
        public DateTime? startedAt { get; set; }
        public DateTime? finishedAt { get; set; }
        public DeliveryStatus status { get; set; }
        public DeliveryMethodResponse deliveryMethod { get; set; }
        [JsonProperty("deliveryLocations")]
        public List<DeliveryLocationResponse> DeliveryLocation { get; set; }
    }
}
