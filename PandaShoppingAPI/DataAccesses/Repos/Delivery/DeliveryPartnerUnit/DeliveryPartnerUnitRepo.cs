using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class DeliveryPartnerUnitRepo : BaseRepo<DeliveryPartnerUnit>, IDeliveryPartnerUnitRepo
    {
        public DeliveryPartnerUnitRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
