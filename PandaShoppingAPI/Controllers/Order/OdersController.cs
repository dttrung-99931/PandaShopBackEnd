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
    public class OrdersController : CrudApiController2<Order_, OrderModel,
            OrderResponseModel, IOrderService, OrderFilter>
    {
        public OrdersController(IOrderService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor)
        {
        }

        [HttpPut("{id}/StartProcessing")]
        public ActionResult<ResponseWrapper> StartProcessingOrder(int id)
        {
            return Handle(() =>
            {
                _service.StartProcessingOrder(id);
                return ok_update();
            });
        }

        [HttpPut("{id}/CompleteProcessing")]
        public ActionResult<ResponseWrapper> CompleteProcessing(int id)
        {
            return Handle(() =>
            {
                _service.StartProcessingOrder(id);
                return ok_update();
            });
        }
    }
}
