using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using System.Collections.Generic;

namespace PandaShoppingAPI.Services
{
    public interface IDriverRealtimeService 
    {
        void NotifyDriverTakeDelivery(int deliveryId, Delivery delivery);
        void NotifyDelvieryProvgressUpdate(int userId, DeliveryProgressUpdateModel progressUpdate);
        
    }
}
