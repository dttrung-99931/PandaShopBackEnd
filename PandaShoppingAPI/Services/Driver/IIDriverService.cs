using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using System.Collections.Generic;

namespace PandaShoppingAPI.Services
{
    public interface IDriverService : IBaseService<Driver, DriverModel, DriverFilter>, IDriverManagerService
    {
        void CreateDeliveryTracking(int deliveryId, DeliveryDriverTrackingModel trackingModel);
        CurrentDeliveryResponse GetCurrentDelivery(int driverId);
        void StartDelivery(int deliveryId, int driverId);
        void UpdateDriverLocation(DriverLocationModel location);
        void UpdateDeliveryProgress(int deliveryId, DeliveryProgressModel model);
    }
}
