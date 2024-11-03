using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System.Text.Json.Serialization;

namespace PandaShoppingAPI.Models
{
    public class DeliveryProgressModel: BaseModel<DeliveryDriver, DeliveryProgressModel>
    {
        public int distanceInMetter { get; set; }
        public int remainingDistance { get; set; }
        public int durationInMinute { get; set; }
        public decimal driverLat { get; set; }
        public decimal driverLong { get; set; }
        public double driverBearingInDegree { get; set; }

    }
}
