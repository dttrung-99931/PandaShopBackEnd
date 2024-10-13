using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class DeliveryMethod: BaseEntity
    {
        public DeliveryMethod()
        {
            Delivery = new HashSet<Delivery>();
            ProductDeliveryMethod = new HashSet<ProductDeliveryMethod>();
            Order = new HashSet<Order>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public int maxDeliveryHours { get; set; }
        

        public virtual ICollection<Delivery> Delivery { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<ProductDeliveryMethod> ProductDeliveryMethod { get; set; }
    }
}
