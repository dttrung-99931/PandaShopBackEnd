using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Delivery: BaseEntity
    {
        public int id { get; set; }
        public DateTime? startedAt { get; set; }
        public DateTime? finishedAt { get; set; }
        public int deliveryMethodId { get; set; }
        public DeliveryStatus status { get; set; }
        public int orderId { get; set; }


        public virtual DeliveryMethod deliveryMethod { get; set; }
        public virtual Order order { get; set; }
        public virtual ICollection<DeliveryLocation> DeliveryLocation { get; set; }
    }
}
