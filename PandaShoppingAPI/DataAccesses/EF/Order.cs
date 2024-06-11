using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Order : BaseEntity
    {
        public int id { get; set; }
        public string note { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public OrderStatus status { get; set; }
        public int userId { get; set; }
        public int invoiceId { get; set; }

        public virtual User_ user { get; set; }
        public virtual Invoice invoice { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<NotificationData> NotificationData { get; set; }
        public virtual ICollection<Delivery> Delivery { get; set; }
    }
}
