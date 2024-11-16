using AutoMapper;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public partial class DriverService : IDriverRealtimeService
    {
        public void  NotifyDriverTakeDelivery(int deliveryId, Delivery delivery)
        {
            // TODO: fixed
            int shopUserId = delivery.OrderDelivery.First().order.shop.User_.First().id;
            _realtime.EmitEvent
            (
                shopUserId,
                RelatimeChannels.onDriverTakeDelivery,
                new RealtimeEvent
                {
                    type = RealtimeEventType.DriverTakeDelivery,
                    data = DeliveryWithOrdersResponse.FromDelivery(delivery)
                }
            );        
        }

        public void NotifyDelvieryProvgressUpdate(int userId, DeliveryProgressUpdateModel progressUpdate)
        {
            _realtime.EmitEvent
            (
                userId,
                RelatimeChannels.onDeliveryProgress,
                new RealtimeEvent
                {
                    type = RealtimeEventType.DeliveryProgressUpdate,
                    data = progressUpdate,
                }
            );
        }


    }
}
