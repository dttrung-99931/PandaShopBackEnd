using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class OrderDetailRepo : BaseRepo<Order>, IOrderDetailRepo
    {
        public OrderDetailRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
