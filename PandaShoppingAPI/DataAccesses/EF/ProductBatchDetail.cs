using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class ProductBatchDetail
    {
        public ProductBatchDetail()
        {
            WarehouseOutputDetail = new HashSet<WarehouseOutputDetail>();
        }

        public int id { get; set; }
        public int productBatchId { get; set; }
        public int productOptionId { get; set; }
        public int number { get; set; }
        public DateTime manufactureDate { get; set; }
        public DateTime? expireDate { get; set; }

        public virtual ProductBatch productBatch { get; set; }
        public virtual ProductOption productOption { get; set; }
        public virtual ICollection<WarehouseOutputDetail> WarehouseOutputDetail { get; set; }
    }
}
