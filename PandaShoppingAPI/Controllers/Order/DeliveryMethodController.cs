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
    public class DeliveryMethodController : CrudApiController2<DeliveryMethod, DeliveryMethodModel,
            DeliveryMethodResponse, IDeliveryMethodService, Filter>
    {
        public DeliveryMethodController(IDeliveryMethodService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor)
        {
        }
    }
}
