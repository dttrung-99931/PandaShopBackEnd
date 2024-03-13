using AutoMapper;
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
using System.Net;

namespace PandaShoppingAPI.Controllers
{
    [Route("v1/[controller]")]
    public class ProductsController : CrudApiController<Product, ProductModel,
            ShortProductResponse, IProductService, ProductFilter>
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

        [HttpPost("{id}/PropertyValues")]
        public ActionResult<ResponseWrapper> InsertPropertyValues(
            int id, [FromBody] List<PropertyValueRequest> propertyValueReqs)
        {
            IDsResponseModel propertyValueIDs = null;
            var exceptionResponse = HandleExceptions(
                    () => propertyValueIDs  = _service.InsertPropertyValues(id, propertyValueReqs)
                );
        
            return exceptionResponse == null ? ok_create(propertyValueIDs) : exceptionResponse;
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

        [HttpPost("{id}/Images")]
        public ActionResult<ResponseWrapper> InsertImages(
            int id, [FromBody] List<ProductImageRequest> images)
        {
            List<ProductImageResponse> insertedImages = null;
            
            var exceptionResponse = HandleExceptions(() =>
                    {
                        insertedImages = Mapper.Map<List<ProductImageResponse>>
                        (
                            _service.InsertImages(id, images)
                        );
                    }
                );

            return exceptionResponse == null ? ok_create(insertedImages) : exceptionResponse;
        }

        [HttpGet("{id}/Images")]
        public ActionResult<ResponseWrapper> GetImages(int id)
        {
            List<ProductImageResponse> images = null;

            var exceptionResponse = HandleExceptions(() =>
                    {
                        images = Mapper.Map<List<ProductImageResponse>>
                        (
                            _service.GetById(id).ProductImage
                        );
                    }
                );

            return exceptionResponse == null ? ok_create(images) : exceptionResponse;
        }

        [HttpPut("{id}/Images")]
        public ActionResult<ResponseWrapper> UpdateImages(
           int id, [FromBody] List<ProductImageRequest> images)
        {
            var exceptionResponse = HandleExceptions(
                    () => _service.UpdateImages(id, images)
                );

            return exceptionResponse == null ? ok_update() : exceptionResponse;
        }

        [HttpPost("{id}/Options")]
        public ActionResult<ResponseWrapper> UpdateOption(
           int id, [FromBody] ProductOptionRequest option)
        {
            IDResponseModel response = null;
            var exceptionResponse = HandleExceptions(
                    () => response = _service.CreateProductOption(id, option)
                );

            return exceptionResponse == null ? ok_create(response) : exceptionResponse;
        }

        [HttpDelete("{id}/Options")]
        public ActionResult<ResponseWrapper> DeleteProductOptions(
            int id, [FromBody] List<int> productOptionIDs)
        {
            var exceptionResponse = HandleExceptions(
                    () => _service.DeleteProductOptions(id, productOptionIDs)
                );

            return exceptionResponse == null ? ok_delete() : exceptionResponse;
        }


        public override ActionResult<ResponseWrapper> Get(int id)
        {
            ProductDetailResponse response = null;

            var exceptionResponse = HandleExceptions(() =>
            {
                response = Mapper.Map<ProductDetailResponse>
                (
                    _service.GetById(id)
                );
            });

            return exceptionResponse == null ? ok_get(response) : notFound();
        }

        [HttpGet("SearchSuggestions")]
        public ActionResult<ResponseWrapper> GetSearchSuggestions(
            [FromQuery] SearchSuggestionRequest requesModel)
        { 
            SearchSuggestion suggestions = null;

            var exceptionResponse = HandleExceptions(() =>
            {
                suggestions = _service.GetSearchSuggestions(requesModel);
            });

            return exceptionResponse == null ? ok_get(suggestions) : exceptionResponse;
        }

        [ApiExplorerSettings(IgnoreApi = true)] // Hide API in swagger
        public override ActionResult<ResponseWrapper> Put(int id, [FromBody] ProductModel requestModel)
        {
            // return forbidden error if api is accessed
            return forbidden(); 
        }

        [HttpPut("{id}", Order = -1)] // order = -1 to override API route of [Put] in supper
        public ActionResult<ResponseWrapper> UpdateProduct(int id, [FromBody] UpdateProductModel updateModel)
        {
            var exceptionResponse = HandleExceptions(
                () => _service.UpdateProduct(id, updateModel)
            );

            return exceptionResponse == null ? ok_update() : exceptionResponse;
        }
    }
}
