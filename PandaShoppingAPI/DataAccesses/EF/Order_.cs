using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Order_ : BaseEntity
    {
        public Order_()
        {
            Invoice = new HashSet<Invoice>();
            SubOrder = new HashSet<SubOrder>();
        }

        public int id { get; set; }
        public string note { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public int userId { get; set; }
        public int paymentMethodId { get; set; }
        

        public virtual PaymentMethod paymentMethod { get; set; }
        public virtual User_ user { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<SubOrder> SubOrder { get; set; }
    }
}
