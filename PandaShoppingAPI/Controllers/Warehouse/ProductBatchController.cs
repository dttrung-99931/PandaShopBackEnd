﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.Controllers.Base;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Models.Base;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PandaShoppingAPI.Controllers
{
    [Route("v1/[controller]")]
    [Authorize(Roles = "shop")]
    public class ProductBatchController : CrudApiController2<ProductBatch, ProductBatchModel,
            ProductBatchResponse, IProductBatchService, Filter>
    {
        public ProductBatchController(IProductBatchService service, IHttpContextAccessor httpContextAccessor)
            : base(service, httpContextAccessor)
                {
                }



        [HttpPost("Many")]
        virtual public ActionResult<ResponseWrapper> Post([FromBody] List<ProductBatchModel> requestModel)
        {
            return Handle(() =>
            {
                List<ProductBatch> batches =  _service.CreateMany(requestModel);
                return ok_create(Constants.SUCCESSFUL_MSG, batches.Select(batch => batch.id));
            });
        }

    }
}
