using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class WarehouseInput : BaseEntity
    {
        public WarehouseInput()
        {
            ProductBatch = new HashSet<ProductBatch>();
        }

        public int id { get; set; }
        public int warehouseId { get; set; }
        public DateTime date { get; set; }
        

        public virtual Warehouse warehouse { get; set; }
        public virtual ICollection<ProductBatch> ProductBatch { get; set; }
    }
}
