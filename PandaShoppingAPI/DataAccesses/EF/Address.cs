using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Address: BaseEntity
    {
        public Address()
        {
            Delivery = new HashSet<Delivery>();
            Product = new HashSet<Product>();
            Warehouse = new HashSet<Warehouse>();
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
        [Precision(12, 9)]
        public decimal lat { get; set; }
        [Precision(12, 9)]
        public decimal long_ { get; set; }

        public virtual User_ user { get; set; }
        public virtual ICollection<Delivery> Delivery { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Warehouse> Warehouse { get; set; }
    }
}
