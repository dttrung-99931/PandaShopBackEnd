using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Resource : BaseEntity
    {
        public Resource()
        {
            Permission = new HashSet<Permission>();
        }

        public int id { get; set; }
        public string name { get; set; }
        

        public virtual ICollection<Permission> Permission { get; set; }
    }
}
