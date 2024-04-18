﻿using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class WarehouseOutputDetail
    {
        public int id { get; set; }
        public int warehouseOutputId { get; set; }
        public int productBatchId { get; set; }
        public int number { get; set; }
        public override bool isDeleted { get; set; }

        public virtual ProductBatch productBatch { get; set; }
        public virtual WarehouseOutput warehouseOutput { get; set; }
    }
}
