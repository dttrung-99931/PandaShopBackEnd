using System;

namespace PandaShoppingAPI.Services
{
    public class CategoryFilter: Filter
    {
        public int? parentId { get; set; }
        public int? level { get; set; }
        // Filter cates that shop registered products in
        public int? shopId { get; set; }
    }
}