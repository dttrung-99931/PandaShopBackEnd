using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Services
{
    public interface IOrderService : IBaseService<Order, OrderModel, OrderFilter>, IOrderProcessService
    {
        // Return list of tmp delivery containing completeProcessing orders 
        // each delivery contains maximum Constants..DELIVERY_ORDER_SIZE orders
        List<TempDeliveryResponse> GetCompleteProcessingOrders();

        // Return list of waiting partner delivery orders 
        // each delivery contains maximum Constants..DELIVERY_ORDER_SIZE orders
        List<DeliveryWithOrdersResponse> GetWaitingPartnerDeliveryOrders();

        // List<TempDeliveryResponse> GetWaitingForDelevringOrders();
        List<Order> Insert(CreateOrdersModel model);
    }
}
