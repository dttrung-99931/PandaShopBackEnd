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
    public class ProductsController : CrudApiController<Product, ProductModel,
            ProductResponse, IProductService, ProductFilter>
    {
        public ProductsController(IProductService service) : base(service)
        {
        }

        [HttpPut("{id}/PropertyValues")]
        public ActionResult<ResponseWrapper> UpdatePropertyValues(
            int id, [FromBody] List<PropertyValueRequest> propertyValueReqs)
        {
            var exceptionResponse = HandleExceptions(
                    () => _service.UpdatePropertyValues(id, propertyValueReqs)
                );
        
            return exceptionResponse == null ? ok_update() : exceptionResponse;
        }

        [HttpDelete("{id}/PropertyValues")]
        public ActionResult<ResponseWrapper> DeletePropertyValues(
            int id, [FromBody] List<int> propertyValueIDs)
        {
            var exceptionResponse = HandleExceptions(
                    () => _service.DeletePropertyValues(id, propertyValueIDs)
                );
        
            return exceptionResponse == null ? ok_delete() : exceptionResponse;
        }

    }
}
