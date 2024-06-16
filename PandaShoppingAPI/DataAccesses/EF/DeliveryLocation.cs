using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class DeliveryLocation: BaseEntity
    {
        public int id { get; set; }
        public LocationType locationType { get; set; }
        public int deliveryId { get; set; }
        public int addressId { get; set; }
        // Order of location in locations that driver need to go to  
        // public int locationOrder { get; set; }
        public virtual Address address { get; set; }
        public virtual Delivery delivery { get; set; }
    }
}
