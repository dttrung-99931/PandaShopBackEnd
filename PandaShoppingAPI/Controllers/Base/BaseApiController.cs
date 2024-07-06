using AutoMapper;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using PandaShoppingAPI.Models;
using System.Collections.Generic;
using PandaShoppingAPI.Utils.Exceptions;
using System.Linq;
using Castle.Core.Internal;

namespace PandaShoppingAPI.Controllers
{
    //[EnableCors("PolicyAll")]
    [ApiController]
    public class BaseApiController<TService> : ControllerBase 
    {
        protected readonly TService _service;
        
        public BaseApiController(TService service)
        {
            _service = service;
        }

        protected ActionResult<ResponseWrapper> error(HttpStatusCode code, string msg)
        {
            return StatusCode
            (
                (int)code,
                new ResponseWrapper(code, msg)
            );
        }

        protected ActionResult<ResponseWrapper> unknownError(string msg)
        {
            return error(HttpStatusCode.InternalServerError, msg);
        }

        protected ActionResult<ResponseWrapper> conflict(string msg, ErrorCode errorCode)
        {
            return StatusCode
            (
                (int)HttpStatusCode.Conflict,
                new ResponseWrapper(HttpStatusCode.Conflict, msg, errorCode.ToString())
            );
        }

        protected ActionResult<ResponseWrapper> ok_get(object data, Meta meta = null)
        {
            return StatusCode
            (
                (int)HttpStatusCode.OK,
                new ResponseWrapper(HttpStatusCode.OK, data, meta)
            );
        }

        protected ActionResult<ResponseWrapper> ok_get()
        {
            return StatusCode
            (
                (int)HttpStatusCode.OK,
                new ResponseWrapper(HttpStatusCode.OK, "Successfully", null)
            );
        }


        /// [createdId] is id/ids of inseted entity/ entiteis 
        protected ActionResult<ResponseWrapper> ok_create(object data, IEnumerable<int> createdIds)
        {
            if (createdIds != null){
                HeaderUtils.SetCreatedIdsToHeader(Response.Headers, createdIds);
            }
            return StatusCode
            (
                (int)HttpStatusCode.Created,
                new ResponseWrapper(HttpStatusCode.Created, data)
            );
        }

        protected ActionResult<ResponseWrapper> ok_update()
        {
            return ok_get(null);
        }

        protected ActionResult<ResponseWrapper> ok_delete()
        {
            return ok_get();
        }

        protected ActionResult<ResponseWrapper> notFound(string msg = "Not found")
        {
            return StatusCode
            (
                (int)HttpStatusCode.NotFound,
                new ResponseWrapper(HttpStatusCode.NotFound, msg)
            );
        }

        protected ActionResult<ResponseWrapper> badRequest(string msg)
        {
            return StatusCode
            (
                (int)HttpStatusCode.BadRequest,
                new ResponseWrapper(HttpStatusCode.BadRequest, msg)
            );

        }

        protected string GetModelStateErrMsg()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var value in ModelState.Values)
            {
                foreach (var error in value.Errors)
                {
                    stringBuilder.Append(error.ErrorMessage);
                }
            }
            return stringBuilder.ToString();
        }

        protected bool HasAdminRole()
        {
            return GetRoleNamesFromToken().Contains("admin");
        }

        private List<string> GetRoleNamesFromToken()
        {
            return GetRoleNamesFromToken(User);
        }
        
        protected List<string> GetRoleNamesFromToken(ClaimsPrincipal user)
        {
            var roleEnumerator = user?.FindAll(ClaimTypes.Role).GetEnumerator();
            var roleNames = new List<string>();
            while (roleEnumerator.MoveNext())
            {
                roleNames.Add(roleEnumerator.Current.Value);
            }
            return roleNames;
        }
        
        protected UserIdentifier GetUserIdentifier()
        {
            return GetUserIdentifier(User);
        }

        protected UserIdentifier GetUserIdentifier(ClaimsPrincipal user)
        {
            return new UserIdentifier(
                GetUserIdFromToken(user), 
                GetCartIdFromToken(user),
                GetShopIdFromToken(user), 
                GetRoleNamesFromToken(user),
                GetDriverIdFromToken(user)
            );
        }

        private int GetAccountIdFromToken()
        {
            try
            {
                var accountIdStr = User?.FindFirst(Constants.CLAIM_ACCOUNT_ID)?.Value;
                return int.Parse(accountIdStr);
            }
            catch (Exception)
            {
                throw new Exception("Access token is obsolete. " +
                    "Please, request a new access token then try again.");
            }
        }

        // Use to check if an operation is valid.
        // An operation is valid when 
        // it executing on data of user (customer or garage ...)
        protected bool IsValidOperationOnUserData(int userId)
        {
            return GetUserIdFromToken() == userId;
        }

        protected int GetUserIdFromToken()
        {
            return GetUserIdFromToken(User);
        }

        protected int GetUserIdFromToken(ClaimsPrincipal user)
        {
            try
            {
                return int.Parse(
                    user?.FindFirst(Constants.CLAIM_USER_ID)?.Value
                );
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetUserIdFromToken " + e.Message);
                return -1;
            }
        }
        
        protected int GetDriverIdFromToken()
        {
            return GetUserIdFromToken(User);
        }

        protected int GetDriverIdFromToken(ClaimsPrincipal user)
        {
            try
            {
                return int.Parse(
                    user?.FindFirst(Constants.CLAIM_DRIVER_ID)?.Value
                );
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetDriverIdFromToken " + e.Message);
                return -1;
            }
        }

        protected int GetCartIdFromToken(ClaimsPrincipal user)
        {
            try
            {
                return int.Parse(
                    user?.FindFirst(Constants.CLAIM_CART_ID)?.Value
                );
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetCartIdFromToken " + e.Message);
                return -1;
            }
        }

        protected int GetShopIdFromToken(ClaimsPrincipal user)
        {
            try
            {
                return int.Parse(
                    user?.FindFirst(Constants.CLAIM_SHOP_ID)?.Value
                );
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetCartIdFromToken " + e.Message);
                return -1;
            }
        }

        protected ActionResult<ResponseWrapper> error_operation_forbidden()
        {
            return error(HttpStatusCode.Forbidden, "Operation forbidden. " +
                "Make sure that your access token containing this operation execution right ");
        }

        protected ActionResult<ResponseWrapper> forbidden()
        {
            return error(HttpStatusCode.Forbidden, "API forbidden");
        }

        protected ActionResult<ResponseWrapper> error_invalid_user()
        {
            return error(HttpStatusCode.Forbidden, "Invalid user. " +
                "Make sure that you have valid access token");
        }

        protected bool UserCallAPIWithToken(ClaimsPrincipal user)
        {
            return GetUserIdFromToken(user) != -1;
        }

        /// <summary>
        /// Utils function to centerlize api error handle 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>
        ///     success ActionResult<ResponseWrapper> if ok 
        ///     error ActionResult<ResponseWrapper>  otherwise
        /// </returns>
        protected ActionResult<ResponseWrapper> Handle(Func<ActionResult<ResponseWrapper>> handler)
        {
            ActionResult<ResponseWrapper> result = null; 
            ActionResult<ResponseWrapper> errorResult = null;
            errorResult = HandleExceptions(() =>
            {
                result = handler();
            });
            return result ?? errorResult;
        }

        protected ActionResult<ResponseWrapper> HandleExceptions(Action action)
        {
            if (!ModelState.IsValid)
            {
                return error(HttpStatusCode.BadRequest, GetModelStateErrMsg());
            }
            
            try
            {
                action.Invoke();
            }
            catch (BadRequestException e)
            {
                return badRequest(e.Message);
            }
            catch (KeyNotFoundException e)
            {
                return notFound(e.Message);
            }
            catch (ConflictException e)
            {
                return conflict(e.Message, e.errorCode);
            }
            catch (ForbiddenException e)
            {
                return forbid(e.Message);
            }
            catch (Exception e)
            {
                return unknownError(e.Message);
            }
            
            return null;
        }

        private ActionResult<ResponseWrapper> forbid(string message)
        {
            return new ResponseWrapper(HttpStatusCode.Forbidden, message);
        }


    }
}
