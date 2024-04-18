using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class DeliveryMethod
    {
        public DeliveryMethod()
        {
            Delivery = new HashSet<Delivery>();
            ProductDeliveryMethod = new HashSet<ProductDeliveryMethod>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public int maxDeliveryHours { get; set; }
        public override bool isDeleted { get; set; }

        public virtual ICollection<Delivery> Delivery { get; set; }
        public virtual ICollection<ProductDeliveryMethod> ProductDeliveryMethod { get; set; }
    }
}
