﻿using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class DeliveryLocation: BaseEntity
    {
        public int id { get; set; }
        public LocationType locationType { get; set; }
        public int deliveryId { get; set; }
        public int addressId { get; set; }
        public virtual Address address { get; set; }
        public virtual Delivery delivery { get; set; }
    }
}
