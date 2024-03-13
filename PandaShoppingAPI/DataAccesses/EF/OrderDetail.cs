﻿using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class OrderDetail
    {
        public int id { get; set; }
        public DateTime? createdAt { get; set; }
        public double? discountPercent { get; set; }
        public decimal price { get; set; }
        public int productNum { get; set; }
        public int orderId { get; set; }
        public int productOptionId { get; set; }

        public virtual Order_ order { get; set; }
        public virtual ProductOption productOption { get; set; }
    }
}
