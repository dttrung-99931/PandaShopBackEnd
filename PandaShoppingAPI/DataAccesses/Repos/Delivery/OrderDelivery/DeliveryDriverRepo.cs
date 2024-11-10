using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class OrderDeliveryRepo : BaseRepo<OrderDelivery>, IOrderDeliveryRepo
    {
        public OrderDeliveryRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
