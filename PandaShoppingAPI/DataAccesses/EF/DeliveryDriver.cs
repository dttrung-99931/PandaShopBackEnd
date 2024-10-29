using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class DeliveryDriver: BaseEntity
    {
        public int id { get; set; }
        public int deliveryId { get; set; }
        public int driverId { get; set; }
        public virtual Delivery delivery { get; set; }
        public virtual Driver driver { get; set; }
        public virtual ICollection<DeliveryDriverTracking> DeliveryDriverTracking { get; set; }
    }
}
