using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Property
    {
        public Property()
        {
            ProductOptionValue = new HashSet<ProductOptionValue>();
            ProductPropertyValue = new HashSet<ProductPropertyValue>();
            PropertyTemplate = new HashSet<PropertyTemplate>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string secondaryId { get; set; }
        public override bool isDeleted { get; set; }

        public virtual ICollection<ProductOptionValue> ProductOptionValue { get; set; }
        public virtual ICollection<ProductPropertyValue> ProductPropertyValue { get; set; }
        public virtual ICollection<PropertyTemplate> PropertyTemplate { get; set; }
    }
}
