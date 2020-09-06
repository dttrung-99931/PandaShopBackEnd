﻿using AutoMapper;
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

        protected ResponseWrapper error(string msg)
        {
            return error(HttpStatusCode.InternalServerError, msg);
        }

        protected ResponseWrapper ok_get(object data, Meta meta = null)
        {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return new ResponseWrapper(HttpStatusCode.OK, data, meta);
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

        protected bool IsAdmin()
        {
            return GetRoleNameFromToken() == "admin";
        }

        protected string GetRoleNameFromToken()
        {
            return User?.FindFirst(ClaimTypes.Role)?.Value;
        }
        
        protected string GetUsernameFromToken()
        {
            return User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        protected UserIdentifier GetUserIdentifier()
        {
            return new UserIdentifier(
                GetUserIdFromToken(), 
                GetRoleNameFromToken(),
                GetUsernameFromToken(),
                GetAccountIdFromToken()
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
            try
            {
                return int.Parse(
                    User?.FindFirst(Constants.CLAIM_USER_ID)?.Value
                );
            }
            catch (Exception e)
            {
                Debug.WriteLine("GetUserIdFromToken " + e.Message);
                return -1;
            }
        }

        protected ActionResult<ResponseWrapper> error_operation_forbidden()
        {
            return error(HttpStatusCode.Forbidden, "Operation forbidden. " +
                "Make sure that your access token containing this operation execution right ");
        }

        protected ActionResult<ResponseWrapper> error_invalid_user()
        {
            return error(HttpStatusCode.Forbidden, "Invalid user. " +
                "Make sure that you have valid access token");
        }

        protected bool IsInvalidUser()
        {
            return GetUserIdFromToken() == -1;
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
            catch (KeyNotFoundException e)
            {
                return notFound(e.Message);
            }
            catch (ConflictException e)
            {
                return Conflict(e.Message);
            }
            catch (ForbiddenException e)
            {
                return forbid(e.Message);
            }
            catch (Exception e)
            {
                return error(e.Message);
            }
            
            return null;
        }

        private ActionResult<ResponseWrapper> forbid(string message)
        {
            return new ResponseWrapper(HttpStatusCode.Forbidden, message);
        }
    }
}
