﻿using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "shop")]
    public class WarehouseInputController : CrudApiController2<WarehouseInput, WarehouseInputModel,
            WarehouseInputResponse, IWarehouseInputService, Filter>
    {
        public WarehouseInputController(IWarehouseInputService service, IHttpContextAccessor httpContextAccessor)
            : base(service, httpContextAccessor)
                {
                }


    }
}
