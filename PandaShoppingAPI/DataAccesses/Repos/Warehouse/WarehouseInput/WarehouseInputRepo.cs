using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class WarehouseInputRepo : BaseRepo<WarehouseInput>, IWarehouseInputRepo
    {
        public WarehouseInputRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
