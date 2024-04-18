using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class CartDetail
    {
        public int id { get; set; }
        public int productNum { get; set; }
        public int cartId { get; set; }
        public int productOptionId { get; set; }
        public override bool isDeleted { get; set; }

        public virtual Cart cart { get; set; }
        public virtual ProductOption productOption { get; set; }
    }
}
