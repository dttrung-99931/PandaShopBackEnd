// filepath: /PandaShoppingAPI/PandaShoppingAPI/Controllers/PanMusic/PanMusicsController.cs
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
    public class PanMusicsController : BaseApiController<IPanMusicService>
    {

        protected IHttpContextAccessor httpContextAccessor;
        public PanMusicsController(IPanMusicService service, IHttpContextAccessor httpContextAccessor) : base(service)
        {
            var user = httpContextAccessor.HttpContext.User;
            if (UserCallAPIWithToken(user)){
                service.SetUser(GetUserIdentifier(user));
            }
        }

        [HttpGet("my")]
        [Authorize]
        public ActionResult<ResponseWrapper> GetMyPanMusics([FromQuery] PanMusicFilter filter)
        {
            return Handle(() => 
            {
                List<PanMusicResponse> panmusics = _service.GetMyPanMusics(filter, out Meta meta);
                return ok_get(panmusics, meta);
            });
        }        

        [HttpGet("feed")]
        public ActionResult<ResponseWrapper> GetPanMusics([FromQuery] PanMusicFilter filter)
        {
            return Handle(() => 
            {
                List<PanMusicResponse> panmusics = _service.GetPanMusics(filter, out Meta meta);
                return ok_get(panmusics, meta);
            });
        }        

        [HttpPost]
        [Authorize]
        public ActionResult<ResponseWrapper> CreatePanMusic([FromForm] CreatePanMusicRequest request)
        {
            return Handle(() => 
            {
                CreatePanMusicResponse panmusic = _service.CreatePanMusic(request);
                return ok_create(panmusic, new List<int> { panmusic.id });
            });
        }        

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<ResponseWrapper> DeletePanMusic(int id)
        {
            return Handle(() =>
            {
                _service.DeletePanMusic(id);
                return ok_delete();
            });
        }
    }
}