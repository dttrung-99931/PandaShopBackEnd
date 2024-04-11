using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class DeliveryRepo : BaseRepo<Delivery>, IDeliveryRepo
    {
        public DeliveryRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
