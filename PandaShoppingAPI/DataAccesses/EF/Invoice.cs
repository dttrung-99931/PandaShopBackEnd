using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Invoice: BaseEntity
    {
        public int id { get; set; }
        public DateTime? createdAt { get; set; }
        public string note { get; set; }
        public int paymentMethodId { get; set;  }
        public PaymentStatus paymentStatus { get; set;  }

        public virtual ICollection<Order> Order { get; set; }
        public virtual PaymentMethod paymentMethod { get; set; }
    }
}
