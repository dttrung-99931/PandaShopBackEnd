using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Role : BaseEntity
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
