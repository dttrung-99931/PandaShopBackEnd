using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class UserRole
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int roleId { get; set; }

        public virtual Role role { get; set; }
        public virtual User_ user { get; set; }
    }
}
