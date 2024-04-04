using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class WarehouseOutputDetail
    {
        public int id { get; set; }
        public int warehouseOutputId { get; set; }
        public int productBatchDetailId { get; set; }
        public int number { get; set; }

        public virtual ProductBatchDetail productBatchDetail { get; set; }
        public virtual WarehouseOutput warehouseOutput { get; set; }
    }
}
