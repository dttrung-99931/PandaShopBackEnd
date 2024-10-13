using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class DeliveryPartner: BaseEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        
        public virtual ICollection<DeliveryPartnerUnit> DeliveryPartnerUnit { get; set; }
    }
}
