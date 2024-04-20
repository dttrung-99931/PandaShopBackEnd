using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class CartDetail: BaseEntity
    {
        public int id { get; set; }
        public int productNum { get; set; }
        public int cartId { get; set; }
        public int productOptionId { get; set; }

        public virtual Cart cart { get; set; }
        public virtual ProductOption productOption { get; set; }
    }
}
