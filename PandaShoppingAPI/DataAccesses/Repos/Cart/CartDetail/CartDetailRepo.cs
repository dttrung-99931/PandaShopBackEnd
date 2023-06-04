using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class CartDetailRepo: BaseRepo<CartDetail>, ICartDetailRepo
    {
        public CartDetailRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }

        public override void Update(CartDetail entityToUpdate, object id)
        {
            Update(entityToUpdate, id, 
                changeUpdate => changeUpdate
                    .Property(cartDetail => cartDetail.cartId).IsModified = false
            );
        }
    }
}
