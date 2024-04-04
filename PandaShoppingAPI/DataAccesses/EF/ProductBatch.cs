using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class ProductBatch
    {
        public ProductBatch()
        {
            ProductBatchDetail = new HashSet<ProductBatchDetail>();
            WarehouseInput = new HashSet<WarehouseInput>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }

        public virtual ICollection<ProductBatchDetail> ProductBatchDetail { get; set; }
        public virtual ICollection<WarehouseInput> WarehouseInput { get; set; }
    }
}
