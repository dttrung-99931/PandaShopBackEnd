using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class PropertyTemplate : BaseEntity
    {
        public PropertyTemplate()
        {
            PropertyTemplateValue = new HashSet<PropertyTemplateValue>();
        }

        public int id { get; set; }
        public int templateId { get; set; }
        public int propertyId { get; set; }
        public bool? isRequired { get; set; }
        public int? orderIndex { get; set; }
        

        public virtual Property property { get; set; }
        public virtual Template template { get; set; }
        public virtual ICollection<PropertyTemplateValue> PropertyTemplateValue { get; set; }
    }
}
