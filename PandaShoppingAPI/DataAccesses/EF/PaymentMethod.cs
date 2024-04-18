using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Order_ = new HashSet<Order_>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public override bool isDeleted { get; set; }

        public virtual ICollection<Order_> Order_ { get; set; }
    }
}
