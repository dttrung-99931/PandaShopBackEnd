using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class DeliveryLocationRepo : BaseRepo<DeliveryLocation>, IDeliveryLocationRepo
    {
        public DeliveryLocationRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
