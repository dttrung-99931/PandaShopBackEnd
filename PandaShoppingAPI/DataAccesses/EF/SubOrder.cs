using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class SubOrder
    {
        public SubOrder()
        {
            SubOrderDetail = new HashSet<SubOrderDetail>();
        }

        public int id { get; set; }
        public int orderId { get; set; }
        public int deliveryId { get; set; }

        public virtual Delivery delivery { get; set; }
        public virtual Order_ order { get; set; }
        public virtual ICollection<SubOrderDetail> SubOrderDetail { get; set; }
    }
}
