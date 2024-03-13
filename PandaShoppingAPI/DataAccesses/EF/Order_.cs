using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Order_
    {
        public Order_()
        {
            Invoice = new HashSet<Invoice>();
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int id { get; set; }
        public string note { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public int addressId { get; set; }
        public int userId { get; set; }
        public int deliveryId { get; set; }
        public int paymentMethodId { get; set; }

        public virtual Address address { get; set; }
        public virtual Delivery delivery { get; set; }
        public virtual PaymentMethod paymentMethod { get; set; }
        public virtual User_ user { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
