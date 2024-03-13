using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class PropertyTemplateValue
    {
        public int id { get; set; }
        public int propertyTemplateId { get; set; }
        public string value { get; set; }

        public virtual PropertyTemplate propertyTemplate { get; set; }
    }
}
