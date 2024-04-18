using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Template
    {
        public Template()
        {
            Category = new HashSet<Category>();
            PropertyTemplate = new HashSet<PropertyTemplate>();
        }

        public int id { get; set; }
        public override bool isDeleted { get; set; }

        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<PropertyTemplate> PropertyTemplate { get; set; }
    }
}
