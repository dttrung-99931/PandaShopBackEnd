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

        public DriverService(IDriverRepo repo, IUserRepo userRepo, IDeliveryRepo deliveryRepo) : base(repo)
        {
            _userRepo = userRepo;
            _deliveryRepo = deliveryRepo;
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
    }
}
