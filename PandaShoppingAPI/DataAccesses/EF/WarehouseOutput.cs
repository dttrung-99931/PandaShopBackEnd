using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class WarehouseOutput
    {
        public WarehouseOutput()
        {
            WarehouseOutputDetail = new HashSet<WarehouseOutputDetail>();
        }

        public int id { get; set; }
        public DateTime date { get; set; }
        public override bool isDeleted { get; set; }

        public virtual ICollection<WarehouseOutputDetail> WarehouseOutputDetail { get; set; }
    }
}
