using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class WarehouseRepo : BaseRepo<Warehouse>, IWarehouseRepo
    {
        public WarehouseRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
