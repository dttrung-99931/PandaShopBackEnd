using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.Controllers.Base;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;
using System.Collections.Generic;

namespace PandaShoppingAPI.Controllers
{
    [Route("v1/[controller]")]
    [Authorize(Roles = RoleNames.driver)]
    public class DriversController : CrudApiController2<Driver, DriverModel,
            DriverResponseModel, IDriverService, DriverFilter>
    {
        public DriversController(IDriverService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)] // Hide API in swagger
        public override ActionResult<ResponseWrapper> Post([FromBody] DriverModel requestModel)
        {
            return notFound();
        }

        [ApiExplorerSettings(IgnoreApi = true)] // Hide API in swagger
        public override ActionResult<ResponseWrapper> Put(int id, [FromBody] DriverModel requestModel)
        {
            return notFound();
        }

        [ApiExplorerSettings(IgnoreApi = true)] // Hide API in swagger
        public override ActionResult<ResponseWrapper> Delete(int id)
        {
            return notFound();
        }
        
        /// Update current driver location 
        [HttpPut("UpdateLocation")]
        public ActionResult<ResponseWrapper> UpdateLocation([FromBody] DriverLocationModel location)
        {
            return Handle(() =>
            {
                _service.UpdateDriverLocation(location);
                return ok_update();
            });
        }

        [HttpGet("UpcomingDeliveries")]
        public ActionResult<ResponseWrapper> GetUpcomingDeliveries([FromQuery] UpcomingDeliveriesFilter filter)
        {
            return Handle(() =>
            {
                List<DeliveryResponse> deliveries =  _service.GetUpcomingDeliveries(filter, out Meta meta);
                return ok_get(deliveries, meta);
            });
        }

        [HttpPut("StartDelivery/{id}")]
        public ActionResult<ResponseWrapper> StartDelivery(int id)
        {
            return Handle(() =>
            {
                _service.StartDelivery(id, UserIdentifier.DriverId);
                return ok_update();
            });
        }

        [HttpPost("Delivery/{deliveryId}/Tracking")]
        public ActionResult<ResponseWrapper> CreateDeliveryTracking(
            [FromRoute] int deliveryId,
            [FromBody] DeliveryDriverTrackingModel trackingModel)
        {
            return Handle(() =>
            {
                _service.CreateDeliveryTracking(deliveryId, trackingModel);
                return ok_update();
            });
        }

        [HttpGet("CurrentDelivery")]
        public ActionResult<ResponseWrapper> GetCurrentDelivery()
        {
            return Handle(() =>
            {
                CurrentDeliveryResponse current = _service.GetCurrentDelivery(UserIdentifier.DriverId);
                return ok_get(current);
            });
        }

    }
}