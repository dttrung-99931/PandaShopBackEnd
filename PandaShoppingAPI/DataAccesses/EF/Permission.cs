using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Permission
    {
        public int id { get; set; }
        public string name { get; set; }
        public int resourceId { get; set; }
        public bool? canRead { get; set; }
        public bool canWrite { get; set; }

        public virtual Resource resource { get; set; }
    }
}
