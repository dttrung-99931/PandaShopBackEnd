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
    public class UsersController : CrudApiController<User_, UserModel,
            UserResponseModel, IUserService, UserFilter>
    {

        public UsersController(IUserService service) : base(service)
        {
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
                return error(e.Message);
            }

            return ok_create("Successfully");
        }

    }
}
