using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class ProductBatchInventory : BaseEntity
    {
        public int id { get; set; }
        public int productBatchId { get; set; }
        public int remainingNumber { get; set; }
        

        public virtual ProductBatch productBatch { get; set; }
    }
}
