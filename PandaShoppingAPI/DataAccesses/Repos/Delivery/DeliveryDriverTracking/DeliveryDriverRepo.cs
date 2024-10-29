using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class DeliveryDriverTrackingRepo : BaseRepo<DeliveryDriverTracking>, IDeliveryDriverTrackingRepo
    {
        public DeliveryDriverTrackingRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
