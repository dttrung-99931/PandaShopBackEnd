using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class OrderRepo : BaseRepo<Order_>, IOrderRepo
    {
        public OrderRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
