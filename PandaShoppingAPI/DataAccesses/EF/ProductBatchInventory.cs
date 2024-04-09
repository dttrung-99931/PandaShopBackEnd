using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class ProductBatchInventory
    {
        public int productBatchId { get; set; }
        public int remainingNumber { get; set; }
        public int id { get; set; }

        public virtual ProductBatch productBatch { get; set; }
    }
}
