using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Image: BaseEntity
    {
        public Image()
        {
            Category = new HashSet<Category>();
            ProductImage = new HashSet<ProductImage>();
            ProductOptionImage = new HashSet<ProductOptionImage>();
        }

        public int id { get; set; }
        public string description { get; set; }
        public string fileName { get; set; }
        

        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<ProductOptionImage> ProductOptionImage { get; set; }
    }
}
