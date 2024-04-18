using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class DeliveryPartner
    {
        public int id { get; set; }
        public string name { get; set; }
        public override bool isDeleted { get; set; }
    }
}
