using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.Controllers.Base;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Controllers
{
    [Route("v1/[controller]")]
    [Authorize(Roles = RoleNames.admin)]
    public class DeliveryController : CrudApiController2<Delivery, DeliveryModel,
            DeliveryResponse, IDeliveryService, DeliveryFilter>
    {
        public DeliveryController(IDeliveryService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor)
        {
        }
    }
}
