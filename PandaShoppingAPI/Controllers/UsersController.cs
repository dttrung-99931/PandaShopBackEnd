using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.Controllers.Base;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;

namespace PandaShoppingAPI.Controllers
{
    [Route("v1/[controller]")]
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
            if (!ModelState.IsValid)
                return error(HttpStatusCode.BadRequest, GetModelStateErrMsg());

            try
            {
                _service.InsertShop(id, shopModel);
            }
            catch (ConflictException)
            {
                return Conflict();
            }
            catch (KeyNotFoundException)
            {
                return notFound();
            }
            catch (Exception e)
            {
                return unknownError(e.Message);
            }

            return ok_create("Successfully");
        }

        [HttpPost("login")]
        public ActionResult<ResponseWrapper> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return error(HttpStatusCode.BadRequest, GetModelStateErrMsg());

            try
            {
                return ok_get(_service.Login(loginModel));   
            }
            catch (ConflictException)
            {
                return Conflict();
            }
            catch (KeyNotFoundException)
            {
                return notFound();
            }
            catch (Exception e)
            {
                return unknownError(e.Message);
            }
        }

    }
}
