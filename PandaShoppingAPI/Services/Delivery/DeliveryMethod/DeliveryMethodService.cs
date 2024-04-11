using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class DeliveryMethodService : BaseService<IDeliveryMethodRepo, DeliveryMethod, DeliveryMethodModel, Filter>, 
        IDeliveryMethodService
    {
        public DeliveryMethodService(IDeliveryMethodRepo repo) : base(repo)
        {
        }
    }
}
