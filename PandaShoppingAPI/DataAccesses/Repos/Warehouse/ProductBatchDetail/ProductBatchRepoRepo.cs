using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class ProductBatchDetailRepo : BaseRepo<ProductBatchDetail>, IProductBatchDetailRepo
    {
        public ProductBatchDetailRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
