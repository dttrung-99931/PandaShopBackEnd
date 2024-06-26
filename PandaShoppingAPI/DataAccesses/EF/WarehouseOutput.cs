﻿using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class WarehouseOutput : BaseEntity
    {
        public WarehouseOutput()
        {
            WarehouseOutputDetail = new HashSet<WarehouseOutputDetail>();
        }

        public int id { get; set; }
        public DateTime date { get; set; }
        

        public virtual ICollection<WarehouseOutputDetail> WarehouseOutputDetail { get; set; }
    }
}
