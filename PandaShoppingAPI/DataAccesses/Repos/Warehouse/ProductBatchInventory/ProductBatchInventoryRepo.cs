using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class ProductBatchInventoryRepo : BaseRepo<ProductBatchInventory>, IProductBatchInventoryRepo
    {
        public ProductBatchInventoryRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
