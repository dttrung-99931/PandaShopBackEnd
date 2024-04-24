using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Services
{
    public interface IOrderService : IBaseService<Order, OrderModel, OrderFilter>, IOrderProcessService
    {
        List<Order> Insert(CreateOrdersModel model);
    }
}
