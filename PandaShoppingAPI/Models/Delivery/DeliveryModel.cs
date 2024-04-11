using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class DeliveryModel: BaseModel<Delivery, DeliveryModel>
    {
        public DateTime? startedAt { get; set; }
        public DateTime? finishedAt { get; set; }
        public string state { get; set; }
        public int deliveryMethodId { get; set; }
    }
}
