using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Controllers
{

    [Route("v1/[controller]")]
    public class PanVideosController : BaseApiController<IPanVideoService>
    {

        protected IHttpContextAccessor httpContextAccessor;
        public PanVideosController(IPanVideoService service, IHttpContextAccessor httpContextAccessor) : base(service)
        {
            var user = httpContextAccessor.HttpContext.User;
            if (UserCallAPIWithToken(user)){
                service.SetUser(GetUserIdentifier(user));
            }
        }

        [HttpGet("my")]
        [Authorize]
        public ActionResult<ResponseWrapper> GetMyPanvideos([FromQuery] PanvideoFilter filter)
        {
            return Handle(() => 
            {
                List<PanVideoResposne> panvideos = _service.GetMyPanvideos(filter, out Meta meta);
                return ok_get(panvideos, meta);
            });
        }        

        [HttpGet("feed")]
        public ActionResult<ResponseWrapper> GetPanvideos([FromQuery] PanvideoFilter filter)
        {
            return Handle(() => 
            {
                List<PanVideoResposne> panvideos = _service.GetPanvideos(filter, out Meta meta);
                return ok_get(panvideos, meta);
            });
        }        

        [HttpPost]
        [Authorize]
        public ActionResult<ResponseWrapper> CreatePanVideo([FromForm] CreatePanVideoRequest request)
        {
            return Handle(() => 
            {
                CreatePanVideoResponse panvideo = _service.CreatePanVideo(request);
                return ok_create(panvideo, new List<int> { panvideo.id });
            });
        }        

        [HttpPost("testConvertStreaming/{id}")]
        public ActionResult<ResponseWrapper> TestConvertStreaming(int id)
        {
            return Handle(() => 
            {
                _service.ConvertPanvideoStreamingInBackground(id);
                return ok_create("Task excuting in background", new List<int> {id});
            });
        }        

        [HttpPost("testConvertAllToStreaming")]
        public ActionResult<ResponseWrapper> TestConvertAllToStreaming()
        {
            return Handle(() => 
            {
                _service.ConvertAllPanvideosToStreamingInBackground();
                return ok_create("Task excuting in background", new List<int> {});
            });
        }        

        [HttpDelete("{id}")]
        [Authorize]
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