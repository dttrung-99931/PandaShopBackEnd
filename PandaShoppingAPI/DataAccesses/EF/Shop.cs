using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Shop
    {
        public Shop()
        {
            Product = new HashSet<Product>();
            User_ = new HashSet<User_>();
            Warehouse = new HashSet<Warehouse>();
        }

        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<User_> User_ { get; set; }
        public virtual ICollection<Warehouse> Warehouse { get; set; }
    }
}
