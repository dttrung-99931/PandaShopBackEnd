using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class ProductBatch
    {
        public ProductBatch()
        {
            InversewarehouseInput = new HashSet<ProductBatch>();
            WarehouseOutputDetail = new HashSet<WarehouseOutputDetail>();
        }

        public int id { get; set; }
        public int warehouseInputId { get; set; }
        public int productOptionId { get; set; }
        public int number { get; set; }
        public DateTime manufactureDate { get; set; }
        public DateTime? expireDate { get; set; }
        public DateTime? arriveDate { get; set; }

        public virtual ProductOption productOption { get; set; }
        public virtual ProductBatch warehouseInput { get; set; }
        public virtual ICollection<ProductBatch> InversewarehouseInput { get; set; }
        public virtual ICollection<WarehouseOutputDetail> WarehouseOutputDetail { get; set; }
    }
}
