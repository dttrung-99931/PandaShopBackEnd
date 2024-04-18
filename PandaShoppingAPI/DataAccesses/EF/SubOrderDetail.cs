using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class SubOrderDetail
    {
        public int id { get; set; }
        public DateTime? createdAt { get; set; }
        public double? discountPercent { get; set; }
        public decimal price { get; set; }
        public int productNum { get; set; }
        public int productOptionId { get; set; }
        public int subOrderId { get; set; }
        public override bool isDeleted { get; set; }

        public virtual ProductOption productOption { get; set; }
        public virtual SubOrder subOrder { get; set; }
    }
}
