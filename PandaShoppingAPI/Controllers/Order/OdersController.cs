using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.Controllers.Base;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Controllers
{
    [Route("v1/[controller]")]
    [Authorize(Roles = "shop")]
    public class OrdersController : CrudApiController2<Order, OrderModel,
            OrderResponseModel, IOrderService, OrderFilter>
    {
        public OrdersController(IOrderService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor)
        {
        }


        [HttpPost(Order = -1)] // Mark -1 to override default insert api route
        public ActionResult<ResponseWrapper> Insert(CreateOrdersModel model)
        {
            return Handle(() =>
            {
                _service.Insert(model);
                return ok_create(Constants.SUCCESSFUL_MSG);
            });
        }

        // Hide default insert API
        [ApiExplorerSettings(IgnoreApi = true)] // Hide API in swagger
        public override ActionResult<ResponseWrapper> Post([FromBody] OrderModel requestModel)
        {
            return notFound();
        }

        [HttpPut(APIPaths.Orders.startProcessing)]
        public ActionResult<ResponseWrapper> StartProcessingOrder(int id)
        {
            return Handle(() =>
            {
                _service.StartProcessingOrder(id);
                return ok_update();
            });
        }

        [HttpPut(APIPaths.Orders.completeProcessing)]
        public ActionResult<ResponseWrapper> CompleteProcessing(int id)
        {
            return Handle(() =>
            {
                _service.CompleteProcessingOrder(id);
                return ok_update();
            });
        }

    }
}
