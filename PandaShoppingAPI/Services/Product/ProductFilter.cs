using System;

namespace PandaShoppingAPI.Services
{
    public class ProductFilter: Filter
    {
        public int? categoryIdLV3 { get; set; }
        public int? categoryIdLV2 { get; set; }
        public int? categoryIdLV1 { get; set; }
    }
}