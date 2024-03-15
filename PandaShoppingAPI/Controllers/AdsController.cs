using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.Controllers.Base;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;
using System.Net;

namespace PandaShoppingAPI.Controllers
{
    [Route("v1/[controller]")]
    public class AdsController : BaseApiController<IAdsService>
    {
        public AdsController(IAdsService service) : base(service)
        {
        }

        [HttpGet("HomeBanners")]
        public ActionResult<ResponseWrapper> HomeBanners()
        {
            return Handle(() =>
            {
                return ok_get(_service.GetHomeBanners());
            });
        }


    }
}
