﻿using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Services
{
    public interface IOrderService : IBaseService<Order_, OrderModel, OrderFilter>, IOrderProcessService
    {
    }
}
