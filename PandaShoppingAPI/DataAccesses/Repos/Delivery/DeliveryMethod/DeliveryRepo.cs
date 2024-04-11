using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class DeliveryMethodRepo : BaseRepo<DeliveryMethod>, IDeliveryMethodRepo
    {
        public DeliveryMethodRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
