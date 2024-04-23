using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public partial class OrderService
    {
        public void CompleteProcessingOrder(int orderId)
        {
            UpdateOrderStatus(orderId, OrderStatus.WaitingForDelivering);
        }

        public void StartProcessingOrder(int orderId)
        {
            UpdateOrderStatus(orderId, OrderStatus.Processing);
        }

        private void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            Order order = _repo.GetById(orderId);
            order.status = status;
            _repo.Update(order, order.id);
        }
    }
}
