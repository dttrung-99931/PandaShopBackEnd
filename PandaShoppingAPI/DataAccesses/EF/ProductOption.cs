using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class ProductOption
    {
        public ProductOption()
        {
            CartDetail = new HashSet<CartDetail>();
            OrderDetail = new HashSet<OrderDetail>();
            ProductBatchDetail = new HashSet<ProductBatchDetail>();
            ProductOptionImage = new HashSet<ProductOptionImage>();
            ProductOptionValue = new HashSet<ProductOptionValue>();
        }

        public int id { get; set; }
        public decimal price { get; set; }
        public string name { get; set; }
        public int productId { get; set; }

        public virtual Product product { get; set; }
        public virtual ICollection<CartDetail> CartDetail { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<ProductBatchDetail> ProductBatchDetail { get; set; }
        public virtual ICollection<ProductOptionImage> ProductOptionImage { get; set; }
        public virtual ICollection<ProductOptionValue> ProductOptionValue { get; set; }
    }
}
