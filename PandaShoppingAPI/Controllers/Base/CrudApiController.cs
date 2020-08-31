using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.Models.Base;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Controllers.Base
{
    public class CrudApiController<TEntity, TRequestModel, TResponseModel, TService, TFilter>:
        BaseApiController<TService>

        where TEntity : class
        where TRequestModel: BaseModel<TEntity, TRequestModel>
        where TResponseModel: BaseModel<TEntity, TResponseModel>
        where TFilter: Filter
        where TService: IBaseService<TEntity, TRequestModel, TFilter>        
    {
        public CrudApiController(TService service) : base(service)
        {
        }

        [HttpGet]
        public ActionResult<ResponseWrapper> Get([FromQuery]TFilter filter)
        {
            Meta meta;

            var filledEntities = _service.Fill(filter, out meta);

            var responseModels = Mapper.Map<List<TResponseModel>>(
                filledEntities
            );

            return ok_get(responseModels, meta);
        }

        [HttpGet("{id}")]
        public ActionResult<ResponseWrapper> Get(int id)
        {
            TResponseModel responseModel;
            try
            {
                responseModel = Mapper.Map<TResponseModel>(
                    _service.GetById(id)
                );
            }
            catch (Exception e)
            {
                return error(HttpStatusCode.InternalServerError, e.Message);
            }

            if (responseModel != null)
                return ok_get(responseModel);

            return notFound();
        }

        [HttpPost]
        public ActionResult<ResponseWrapper> Post([FromBody]TRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return error(HttpStatusCode.BadRequest, GetModelStateErrMsg());

            TResponseModel responseModel;
            
            try
            {
                responseModel = Mapper.Map<TResponseModel>(
                    _service.Insert(requestModel)
                );
            }
            catch (Exception e)
            {
                return error(e.Message);
            }

            return ok_create(responseModel);
        }

        [HttpPut("{id}")]
        public ActionResult<ResponseWrapper> Put(int id, [FromBody] TRequestModel requestModel)
        {
            if (id != requestModel.id)
                return error(HttpStatusCode.BadRequest, "Id in url and body must be the same!");

            if (!_service.Exist(id)) return notFound();

            try
            {
                _service.Update(
                    requestModel, requestModel.id
                 );
            }
            catch (Exception e)
            {
                return error(e.Message);
            }
            return ok_update();
        }


        [HttpDelete("{id}")]
        public ActionResult<ResponseWrapper> Delete(int id)
        {
            if (!_service.Exist(id)) return notFound();

            try
            {
                _service.Delete(id);
            }
            catch (Exception e)
            {
                return error(e.Message);
            }
            return ok_delete();
        }
    }
}
