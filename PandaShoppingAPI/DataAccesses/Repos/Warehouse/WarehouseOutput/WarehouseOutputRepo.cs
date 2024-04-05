using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class WarehouseOutputRepo : BaseRepo<WarehouseOutput>, IWarehouseOutputRepo
    {
        public WarehouseOutputRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
