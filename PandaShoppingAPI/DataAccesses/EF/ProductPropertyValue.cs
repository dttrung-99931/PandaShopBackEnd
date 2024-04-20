using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class ProductPropertyValue : BaseEntity
    {
        public int id { get; set; }
        public string value { get; set; }
        public int productId { get; set; }
        public int propertyId { get; set; }
        

        public virtual Product product { get; set; }
        public virtual Property property { get; set; }
    }
}
