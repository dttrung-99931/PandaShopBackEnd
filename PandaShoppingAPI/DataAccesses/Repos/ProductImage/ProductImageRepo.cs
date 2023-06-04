using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class ProductImageRepo : BaseRepo<ProductImage>, IProductImageRepo
    {
        public ProductImageRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
