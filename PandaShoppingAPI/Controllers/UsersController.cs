using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using PandaShoppingAPI.Controllers.Base;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;
using System.Net;

namespace PandaShoppingAPI.Controllers
{
    [Route("v1/[controller]")]
    [Authorize]
    public class UsersController : CrudApiController2<User_, UserModel,
            UserResponseModel, IUserService, UserFilter>
    {
        public UsersController(IUserService service, IHttpContextAccessor httpContextAccessor) 
            : base(service, httpContextAccessor)
        {
        }

        [Authorize(Roles = "shop")]
        public override ActionResult<ResponseWrapper> Get([FromQuery] UserFilter filter)
        {
            return base.Get(filter);
        }

        [HttpPost("{id}/Shop")]
        public ActionResult<ResponseWrapper> InsertShop(int id, [FromBody] ShopModel shopModel)
        {
            return Handle(() =>
            {
                _service.InsertShop(id, shopModel);
                return ok_create("Successfully");
            });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<ResponseWrapper> Login([FromBody] LoginModel loginModel)
        {
            return Handle(() =>
            {
                LoginResponse result = _service.Login(loginModel);
                return result != null ? ok_get(result) : error(HttpStatusCode.Unauthorized, "Login failed");
            });
        }


        [AllowAnonymous]
        public override ActionResult<ResponseWrapper> Post([FromBody] UserModel requestModel)
        {
            return base.Post(requestModel);
        }

        public override void HandleResponseModel(UserResponseModel response)
        {
            if (response.shop.id <= 0)
            {
                response.shop = null;
            }
        }

        [HttpGet("me")]
        public ActionResult<ResponseWrapper> GetMe()
        {
            return Handle(() =>
            {
                int userId = GetUserIdFromToken();
                return Get(userId);
            });
        }

        public override ActionResult<ResponseWrapper> Get(int id)
        {
            return Handle(() =>
            {
                User_ user = _service.GetById(id);
                if (user == null)
                {
                    throw new NotFoundException("User", id);
                }
                UserResponseModel userRes = Mapper.Map<UserResponseModel>(user);
                // Remove default null shop by AutoMapper
                // TODO: fix AutoMapper mapping field even it's null
                if (user.shopId == null)
                {
                    userRes.shop = null;
                }
                return ok_get(userRes);
            });
        }
    }
}
