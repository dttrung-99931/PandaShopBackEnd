using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class DeliveryResponse: BaseModel<Delivery, DeliveryResponse>
    {
        public DateTime? startedAt { get; set; }
        public DateTime? finishedAt { get; set; }
        public string state { get; set; }
        public DeliveryMethodResponse deliveryMethod { get; set; }
    }
}
