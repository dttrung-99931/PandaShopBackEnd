using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public interface IDeliveryDriverRepo : IBaseRepo<DeliveryDriver>
    {
        Delivery GetCurrentDeliveryOf(int driverId);
    }
}
