using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class ProductBatchRepo : BaseRepo<ProductBatch>, IProductBatchRepo
    {
        public ProductBatchRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
