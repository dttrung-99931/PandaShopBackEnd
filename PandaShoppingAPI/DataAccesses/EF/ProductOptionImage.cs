using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class ProductOptionImage
    {
        public int id { get; set; }
        public int productOptionId { get; set; }
        public int imageId { get; set; }
        public override bool isDeleted { get; set; }

        public virtual Image image { get; set; }
        public virtual ProductOption productOption { get; set; }
    }
}
