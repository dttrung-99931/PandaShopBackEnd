using System;

namespace PandaShoppingAPI.Services
{
    public class OrderFilter : Filter
    {
        public int? shopId { get; set; }
        public int? userId { get; set; }
    }
}