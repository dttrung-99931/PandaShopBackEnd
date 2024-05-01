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
    public class TemplatesController : CrudApiController<Template, TemplateModel,
            TemplateResponseModel, ITemplateService, TemplateFilter>
    {
        
        public TemplatesController(ITemplateService service) : base(service)
        {
        }

        [HttpPost("{id}/Properties")]
        public ActionResult<ResponseWrapper> AddPropertyValues(
            int id, 
            [FromBody] PropertyValuesModel model)
        {
            if (!ModelState.IsValid)
                return error(HttpStatusCode.BadRequest, GetModelStateErrMsg());

            try
            {
                _service.AddPropertyValues(id, model);
            }
            catch (ConflictException)
            {
                return Conflict();
            }
            catch (Exception e)
            {
                return unknownError(e.Message);
            }

            return ok_create("Successfully", null);
        }

        [HttpPut("{id}/Properties")]
        public ActionResult<ResponseWrapper> UpdatePropertyValues(
            int id, [FromBody] PropertyValuesModel model)
        {
            if (!ModelState.IsValid)
                return error(HttpStatusCode.BadRequest, GetModelStateErrMsg());

            if (!_service.Exist(id)) return notFound();

            try
            {
                _service.UpdatePropertyValues(id, model);
            }
            catch (Exception e)
            {
                return unknownError(e.Message);
            }

            return ok_update();
        }

        [HttpDelete("{id}/Properties/{propertyId}")]
        public ActionResult<ResponseWrapper> DeletePropertyValues(int id, int propertyId)
        {
            if (!_service.Exist(id)) return notFound();

            try
            {
                _service.DeletePropertyValues(id, propertyId);
            }
            catch (KeyNotFoundException notFoundEx)
            {
                return notFound(notFoundEx.Message);
            }
            catch (Exception e)
            {
                return unknownError(e.Message);
            }
            return ok_delete();
        }
    }
}
