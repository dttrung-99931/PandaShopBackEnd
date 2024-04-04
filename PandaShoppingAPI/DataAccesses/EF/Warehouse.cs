using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            WarehouseInput = new HashSet<WarehouseInput>();
        }

        public int id { get; set; }
        public int addressId { get; set; }
        public int shopId { get; set; }
        public string name { get; set; }

        public virtual Address address { get; set; }
        public virtual Shop shop { get; set; }
        public virtual ICollection<WarehouseInput> WarehouseInput { get; set; }
    }
}
