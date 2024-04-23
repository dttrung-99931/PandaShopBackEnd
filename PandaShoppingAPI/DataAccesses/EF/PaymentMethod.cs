
using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class PaymentMethod : BaseEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        

        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
