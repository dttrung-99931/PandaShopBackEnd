using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class DeliveryPartnerUnit: BaseEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public int deliveryPartnerId { get; set; }
        public int addressId { get; set; }

        public virtual DeliveryPartner DeliveryPartner { get; set; }
        public virtual Address address { get; set; }
        public virtual ICollection<ProductDeliveryMethod> ProductDeliveryMethod { get; set; }

    }
}
