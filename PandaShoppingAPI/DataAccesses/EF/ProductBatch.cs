using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class ProductBatch
    {
        public ProductBatch()
        {
            ProductBatchInventory = new HashSet<ProductBatchInventory>();
            WarehouseOutputDetail = new HashSet<WarehouseOutputDetail>();
        }

        public int id { get; set; }
        public int warehouseInputId { get; set; }
        public int productOptionId { get; set; }
        public int number { get; set; }
        public DateTime manufactureDate { get; set; }
        public DateTime? expireDate { get; set; }
        public DateTime? arriveDate { get; set; }
        public override bool isDeleted { get; set; }

        public virtual ProductOption productOption { get; set; }
        public virtual WarehouseInput warehouseInput { get; set; }
        public virtual ICollection<ProductBatchInventory> ProductBatchInventory { get; set; }
        public virtual ICollection<WarehouseOutputDetail> WarehouseOutputDetail { get; set; }
    }
}
