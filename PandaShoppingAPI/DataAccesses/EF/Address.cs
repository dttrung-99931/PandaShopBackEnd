using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Address
    {
        public Address()
        {
            Order_ = new HashSet<Order_>();
            Product = new HashSet<Product>();
        }

        public int id { get; set; }
        public string provinceOrCity { get; set; }
        public string provinceOrCityCode { get; set; }
        public string district { get; set; }
        public string districtCode { get; set; }
        public string communeOrWard { get; set; }
        public string streetAndHouseNum { get; set; }
        public int? userId { get; set; }
        public string name { get; set; }

        public virtual User_ user { get; set; }
        public virtual ICollection<Order_> Order_ { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
