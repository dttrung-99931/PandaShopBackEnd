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
    public class CategoriesController : CrudApiController<Category, CategoryModel,
            CategoryResponse, ICategoryService, CategoryFilter>
    {
        public CategoriesController(ICategoryService service) : base(service)
        {
        }

        [HttpPost("{id}/Template")]
        public ActionResult<ResponseWrapper> InsertTemplate(
            int id,
            [FromBody] TemplateModel model)
        {
            if (!ModelState.IsValid)
                return error(HttpStatusCode.BadRequest, GetModelStateErrMsg());

            try
            {
                _service.InsertTemplateForCategory(id, model);
            }
            catch (KeyNotFoundException)
            {
                return notFound();
            }
            catch (ConflictException)
            {
                return Conflict();
            }
            catch (Exception e)
            {
                return unknownError(e.Message);
            }

            return ok_create("Successfully", new List<int> {model.id});
        }

        [HttpGet("{id}/Template")]
        public ActionResult<ResponseWrapper> GetTemplate(int id)
        {
            return Handle(() =>
            {
                return ok_get(_service.GetTemplateOfCate(id));
            });
        }

    }
}
