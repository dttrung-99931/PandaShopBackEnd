using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Category
    {
        public Category()
        {
            Inverseparent = new HashSet<Category>();
            Product = new HashSet<Product>();
        }

        public int id { get; set; }
        public int? parentId { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public int? imageId { get; set; }
        public int? templateId { get; set; }

        public virtual Image image { get; set; }
        public virtual Category parent { get; set; }
        public virtual Template template { get; set; }
        public virtual ICollection<Category> Inverseparent { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
