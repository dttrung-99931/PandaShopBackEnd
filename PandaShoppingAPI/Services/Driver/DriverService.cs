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
    public partial class DriverService : BaseService<IDriverRepo, Driver, DriverModel, DriverFilter>, 
        IDriverService
    {
        private readonly IUserRepo _userRepo;
        private readonly IDeliveryRepo _deliveryRepo;
        private readonly IDeliveryDriverRepo _deliveryDriverRepo;
        private readonly IDeliveryDriverTrackingRepo _deliveryDriverTrkRepo;

        public DriverService(IDriverRepo repo, IUserRepo userRepo, IDeliveryRepo deliveryRepo, IDeliveryDriverRepo deliveryDriverRepo, IDeliveryDriverTrackingRepo deliveryDriverTrkRepo) : base(repo)
        {
            _userRepo = userRepo;
            _deliveryRepo = deliveryRepo;
            _deliveryDriverRepo = deliveryDriverRepo;
            _deliveryDriverTrkRepo = deliveryDriverTrkRepo;
        }

        public void StartDelivery(int deliveryId, int driverId)
        {
            Delivery delivery = _deliveryRepo.GetById(deliveryId);
            ValidateStartDelivery(delivery, driverId);
            delivery.status = DeliveryStatus.Delivering;
            delivery.deliveryDriver = new DeliveryDriver 
            {
                driverId = driverId,
            };
            _deliveryRepo.Update(delivery, deliveryId);
        }

        private void ValidateStartDelivery(Delivery delivery, int driverId)
        {
            if (_deliveryDriverRepo.GetCurrentDeliveryOf(driverId) != null)
            {
                throw new ConflictException(ErrorCode.driverIsNotFreeToDeliver, "Driver is being busy");
            }

            if (delivery.status == DeliveryStatus.Delivering)
            {
                throw new ConflictException(ErrorCode.deliveryWasStarted, "Delivery was started");
            }
        }

        public void UpdateDriverLocation(DriverLocationModel location)
        {
            Driver driver = GetDriver();
            driver.lat = location.lat;
            driver.long_ = location.long_;
            _repo.Update(driver, driver.id);
        }

        private Driver GetDriver()
        {
            Driver driver = _userRepo.GetById(User.UserId).driver;
            if (driver == null)
            {
                throw new NotFoundException("Driver");
            }
            return driver;
        }

        public CurrentDeliveryResponse GetCurrentDelivery(int driverId)
        {
            Delivery current = _deliveryDriverRepo.GetCurrentDeliveryOf(driverId);
            return Mapper.Map<CurrentDeliveryResponse>(current);
        }

        public void CreateDeliveryTracking(int deliveryId, DeliveryDriverTrackingModel trackingModel)
        {
            Delivery delivery = _deliveryRepo.GetById(deliveryId);
            DeliveryDriverTracking tracking = new DeliveryDriverTracking 
            {
                deliveryDriverId = delivery.deliveryDriver.id,
                bearingInDegree = trackingModel.bearingInDegree,
                lat = trackingModel.lat,
                long_ = trackingModel.long_,
                createdAt = DateTime.UtcNow,
            };
            _deliveryDriverTrkRepo.Insert(tracking);
        }

        public void UpdateDeliveryProgress(int deliveryId, DeliveryProgressModel model)
        {
            DeliveryDriver deliveryDriver = _deliveryDriverRepo.GetIQueryable().First(dd => dd.deliveryId == deliveryId);
            deliveryDriver.distanceInMetter = model.distanceInMetter;   
            deliveryDriver.durationInMinute = model.durationInMinute;   
            deliveryDriver.driverLat = model.driverLat;   
            deliveryDriver.driverLong = model.driverLong;   
            deliveryDriver.driverBearingInDegree = model.driverBearingInDegree;
            _deliveryDriverRepo.Update(deliveryDriver, deliveryDriver.id);

        }
    }
}
