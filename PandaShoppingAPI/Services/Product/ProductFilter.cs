using System;

namespace PandaShoppingAPI.Services
{
    public class ProductFilter: Filter
    {
        public const string ASC = "asc";
        public const string DESC = "desc";
        public const string BEING_HOT = "being_hot";

        public int? categoryIdLV3 { get; set; }
        public int? categoryIdLV2 { get; set; }
        public int? categoryIdLV1 { get; set; }
        public string orderBy { get; set; }
        public decimal? fromPrice { get; set; }
        public decimal? toPrice { get; set; }
        public string provinceOrCityCode { get; set; }
    }
}