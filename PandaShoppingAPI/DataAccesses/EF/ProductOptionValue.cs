﻿using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class ProductOptionValue : BaseEntity
    {
        public int id { get; set; }
        public int productOptionId { get; set; }
        public int propertyId { get; set; }
        public string value { get; set; }
        

        public virtual ProductOption productOption { get; set; }
        public virtual Property property { get; set; }
    }
}
