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

        protected ResponseWrapper error(HttpStatusCode code, string msg)
        {
            Response.StatusCode = (int)code;
            return new ResponseWrapper(code, msg);
        }

        protected ResponseWrapper unknownError(string msg)
        {
            return error(HttpStatusCode.InternalServerError, msg);
        }

        protected ResponseWrapper conflict(String msg, ErrorCode errorCode)
        {
            Response.StatusCode = (int)HttpStatusCode.Conflict;
            return new ResponseWrapper(HttpStatusCode.Conflict, errorCode.ToString(), msg);
        }

        protected ResponseWrapper ok_get(object data, Meta meta = null)
        {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return new ResponseWrapper(HttpStatusCode.OK, data, meta);
        }

        protected ResponseWrapper ok_get()
        {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return new ResponseWrapper(HttpStatusCode.OK, "Successfully", null);
        }

        protected ResponseWrapper ok_create(object data)
        {
            Response.StatusCode = (int)HttpStatusCode.Created;
            return new ResponseWrapper(HttpStatusCode.Created, data);
        }

        protected ResponseWrapper ok_update()
        {
            return ok_get(null);
        }

        protected ResponseWrapper ok_delete()
        {
            Response.StatusCode = (int)HttpStatusCode.NoContent;
            return null;
        }

        protected ResponseWrapper notFound()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return new ResponseWrapper(HttpStatusCode.NotFound, "Not found");
        }
        
        protected ResponseWrapper notFound(string msg)
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return new ResponseWrapper(HttpStatusCode.NotFound, msg);
        }

        protected ResponseWrapper badRequest(string msg)
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new ResponseWrapper(HttpStatusCode.BadRequest, msg);
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
                GetRoleNamesFromToken(user)
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

        protected bool UserCallAPIWithToken()
        {
            return GetUserIdFromToken() != -1;
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
