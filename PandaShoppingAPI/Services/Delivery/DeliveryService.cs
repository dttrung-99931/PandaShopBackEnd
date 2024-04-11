using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class DeliveryService : BaseService<IDeliveryRepo, Delivery, DeliveryModel, DeliveryFilter>, 
        IDeliveryService
    {
        public DeliveryService(IDeliveryRepo repo) : base(repo)
        {
        }
    }
}
