using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class DeliveryDriverTracking: BaseEntity
    {
        public int id { get; set; }
        public int deliveryDriverId { get; set; }
        [Precision(12, 9)]
        public decimal lat { get; set; }
        [Precision(12, 9)]
        public decimal long_ { get; set; }
        public double bearingInDegree { get; set; }
        public DateTime createdAt { get; set; }
        public virtual DeliveryDriver deliveryDriver { get; set; }
    }
}
