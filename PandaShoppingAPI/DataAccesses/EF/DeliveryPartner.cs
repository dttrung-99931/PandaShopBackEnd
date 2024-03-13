using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class DeliveryPartner
    {
        public DeliveryPartner()
        {
            DeliveryMethod = new HashSet<DeliveryMethod>();
        }

        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<DeliveryMethod> DeliveryMethod { get; set; }
    }
}
