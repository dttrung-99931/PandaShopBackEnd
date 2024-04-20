using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class ProductOption : BaseEntity
    {
        public ProductOption()
        {
            CartDetail = new HashSet<CartDetail>();
            ProductBatch = new HashSet<ProductBatch>();
            ProductOptionImage = new HashSet<ProductOptionImage>();
            ProductOptionValue = new HashSet<ProductOptionValue>();
            SubOrderDetail = new HashSet<SubOrderDetail>();
        }

        public int id { get; set; }
        public decimal price { get; set; }
        public string name { get; set; }
        public int productId { get; set; }
        

        public virtual Product product { get; set; }
        public virtual ICollection<CartDetail> CartDetail { get; set; }
        public virtual ICollection<ProductBatch> ProductBatch { get; set; }
        public virtual ICollection<ProductOptionImage> ProductOptionImage { get; set; }
        public virtual ICollection<ProductOptionValue> ProductOptionValue { get; set; }
        public virtual ICollection<SubOrderDetail> SubOrderDetail { get; set; }
    }
}
