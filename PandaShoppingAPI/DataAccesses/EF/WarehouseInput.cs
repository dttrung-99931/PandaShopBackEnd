using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class WarehouseInput
    {
        public int id { get; set; }
        public int warehouseId { get; set; }
        public int productBatchId { get; set; }
        public DateTime date { get; set; }

        public virtual ProductBatch productBatch { get; set; }
        public virtual Warehouse warehouse { get; set; }
    }
}
