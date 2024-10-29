using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System.Text.Json.Serialization;

namespace PandaShoppingAPI.Models
{
    public class DeliveryDriverTrackingModel
    {
        public decimal lat { get; set; }
        [JsonPropertyName("long")]
        public decimal long_ { get; set; }
        public double bearingInDegree { get; set; }
    }
}
