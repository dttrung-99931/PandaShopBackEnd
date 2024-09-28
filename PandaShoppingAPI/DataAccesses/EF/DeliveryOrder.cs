using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class OrderDelivery : BaseEntity
    {
        public int id { get; set; }
        public int deliveryId { get; set; }
        public int orderId { get; set; }

        public virtual Delivery delivery { get; set; }
        public virtual Order order { get; set; }
    }
}
