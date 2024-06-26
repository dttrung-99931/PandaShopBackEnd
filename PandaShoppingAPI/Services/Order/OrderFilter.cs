﻿using System;
using PandaShoppingAPI.DataAccesses.EF;

namespace PandaShoppingAPI.Services
{
    public class OrderFilter : Filter
    {
        public int? shopId { get; set; }
        public int? userId { get; set; }
        public OrderStatus? status { get; set; }
    }
}