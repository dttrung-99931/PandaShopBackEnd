using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Invoice: BaseEntity
    {
        public int id { get; set; }
        public DateTime? createdAt { get; set; }
        public string note { get; set; }
        public int orderId { get; set; }
        

        public virtual Order_ order { get; set; }
    }
}
