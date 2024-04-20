using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class CartRepo : BaseRepo<Cart>, ICartRepo
    {
        public CartRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }


    }
}
