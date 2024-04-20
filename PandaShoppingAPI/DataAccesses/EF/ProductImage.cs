using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class ProductImage : BaseEntity
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int imageId { get; set; }
        

        public virtual Image image { get; set; }
        public virtual Product product { get; set; }
    }
}
