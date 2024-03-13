using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Role
    {
        public Role()
        {
            UserRole = new HashSet<UserRole>();
        }

        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
