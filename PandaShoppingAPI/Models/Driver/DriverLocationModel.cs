using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace PandaShoppingAPI.Models
{
    public class DriverLocationModel
    {
        public decimal lat { get; set; }
        [JsonPropertyName("long")]
        public decimal long_ { get; set; }
    }
}
