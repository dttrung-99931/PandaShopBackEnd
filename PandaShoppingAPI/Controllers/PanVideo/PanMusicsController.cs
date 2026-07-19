// filepath: /PandaShoppingAPI/PandaShoppingAPI/Controllers/PanMusic/PanMusicsController.cs
using System.Collections.Generic;
using AutoMapper;
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
            if (UserCallAPIWithToken(user))
            {
                service.SetUser(GetUserIdentifier(user));
            }
        }

        [HttpGet]
        public ActionResult<ResponseWrapper> GetPanMusics([FromQuery] PanMusicFilter filter)
        {
            return Handle(() =>
            {
                List<PanMusicResposne> panmusics = _service.GetPanMusics(filter, out Meta meta);
                return ok_get(panmusics, meta);
            });
        }

        [HttpGet("{id}")]
        public ActionResult<ResponseWrapper> GetPanMusicById(int id)
        {
            return Handle(() =>
            {
                PanMusicResposne panmusic = Mapper.Map<PanMusicResposne>(_service.GetById(id));
                return ok_get(panmusic);
            });
        }


        [HttpGet("my")]
        [Authorize]
        public ActionResult<ResponseWrapper> GetMyPanMusics([FromQuery] PanMusicFilter filter)
        {
            return Handle(() =>
            {
                List<PanMusicResposne> panmusics = _service.GetMyPanMusics(filter, out Meta meta);
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

        [HttpPatch("{id}")]
        [Authorize]
        public ActionResult<ResponseWrapper> PanMusic(
            int id,
            [FromForm] UpdatePanMusicRequest request)
        {
            return Handle(() =>
            {
                _service.UpdatePanMusic(id, request);
                return ok_update();
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