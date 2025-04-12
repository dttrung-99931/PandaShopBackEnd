using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Controllers
{

    [Route("v1/[controller]")]
    [Authorize]
    public class PanVideosController : BaseApiController<IPanVideoService>
    {

        protected IHttpContextAccessor httpContextAccessor;
        public PanVideosController(IPanVideoService service, IHttpContextAccessor httpContextAccessor) : base(service)
        {
            var user = httpContextAccessor.HttpContext.User;
            service.SetUser(GetUserIdentifier(user));
        }

        [HttpPost]
        public ActionResult<ResponseWrapper> CreatePanVideo([FromForm] PanVideoRequest request)
        {
            return Handle(() => 
            {
                PanVideoResponse panvideo = _service.CreatePanVideo(request);
                return ok_create(panvideo, new List<int> { panvideo.id });
            });
        }        

        [HttpDelete("{id}")]
        public ActionResult<ResponseWrapper> DeletePanVideo(int id)
        {
            return Handle(() =>
            {
                _service.DeletePanVideo(id);
                return ok_delete();
            });
        }
    }
}