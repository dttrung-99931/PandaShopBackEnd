using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class ShopRepo : BaseRepo<Shop>, IShopRepo
    {
        public ShopRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
