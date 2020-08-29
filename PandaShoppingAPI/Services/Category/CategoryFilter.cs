using System;

namespace PandaShoppingAPI.Services
{
    public class CategoryFilter: Filter
    {
        public int? parentId { get; set; }
        public int? level { get; set; }
    }
}