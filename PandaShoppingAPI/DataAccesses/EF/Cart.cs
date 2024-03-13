using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Cart
    {
        public Cart()
        {
            CartDetail = new HashSet<CartDetail>();
            User_ = new HashSet<User_>();
        }

        public int id { get; set; }

        public virtual ICollection<CartDetail> CartDetail { get; set; }
        public virtual ICollection<User_> User_ { get; set; }
    }
}
