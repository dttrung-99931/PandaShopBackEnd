using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class OrderService : BaseService<IOrderRepo, Order_, OrderModel, OrderFilter>, 
        IOrderService
    {
        public OrderService(IOrderRepo repo) : base(repo)
        {
        }
    }
}
