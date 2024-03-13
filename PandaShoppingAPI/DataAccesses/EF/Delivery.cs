using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Delivery
    {
        public Delivery()
        {
            Order_ = new HashSet<Order_>();
        }

        public int id { get; set; }
        public DateTime? startedAt { get; set; }
        public DateTime? finishedAt { get; set; }
        public string state { get; set; }
        public int deliveryMethodId { get; set; }

        public virtual DeliveryMethod deliveryMethod { get; set; }
        public virtual ICollection<Order_> Order_ { get; set; }
    }
}
