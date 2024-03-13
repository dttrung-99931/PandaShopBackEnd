using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class DeliveryMethod
    {
        public DeliveryMethod()
        {
            Delivery = new HashSet<Delivery>();
        }

        public int id { get; set; }
        public int deliveryPartnerId { get; set; }
        public string name { get; set; }
        public decimal pricePerKm { get; set; }

        public virtual DeliveryPartner deliveryPartner { get; set; }
        public virtual ICollection<Delivery> Delivery { get; set; }
    }
}
