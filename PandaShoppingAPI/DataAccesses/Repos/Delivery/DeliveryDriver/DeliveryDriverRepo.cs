using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class DeliveryDriverRepo : BaseRepo<DeliveryDriver>, IDeliveryDriverRepo
    {
        public DeliveryDriverRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }

        public Delivery GetCurrentDeliveryOf(int driverId)
        {
            Delivery current = Where(deliDriver => deliDriver.driverId == driverId && deliDriver.delivery.status == DeliveryStatus.Delivering)
                .Select(deliDriver => deliDriver.delivery)
                .FirstOrDefault();
            return current;
        }
    }
}
