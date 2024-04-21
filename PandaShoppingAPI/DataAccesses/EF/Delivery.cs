using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Delivery: BaseEntity
    {
        public Delivery()
        {
            SubOrder = new HashSet<SubOrder>();
        }

        public int id { get; set; }
        public DateTime? startedAt { get; set; }
        public DateTime? finishedAt { get; set; }
        public int deliveryMethodId { get; set; }
        public int addressId { get; set; }
        public DeliveryStatus status { get; set; }


        public virtual Address address { get; set; }
        public virtual DeliveryMethod deliveryMethod { get; set; }
        public virtual ICollection<SubOrder> SubOrder { get; set; }
    }
}
