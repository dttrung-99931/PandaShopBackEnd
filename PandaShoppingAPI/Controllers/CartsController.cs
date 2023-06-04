using AutoMapper;
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
    [Authorize]
    [Route("v1/[controller]")]
    public class CartsController : CrudApiController2<Cart, CartModel,
            CartResponse, ICartService, CartFilter>
    {
        public CartsController(ICartService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor)
        {
        }

        [HttpPost("AddToCart")]
        public ActionResult<ResponseWrapper> AddToCart([FromBody] CartDetailModel request)
        {
            CartDetailModel cartDetail = null;
            var exceptionResponse = HandleExceptions(() =>
            {
                cartDetail = Mapper.Map<CartDetailModel>(
                 _service.AddToCart(request)
                );
            });

            if (exceptionResponse != null) return exceptionResponse;

            return ok_create(cartDetail);
        }        
        
        [HttpPut("UpdateCartDetail/{cartDetailId}")]
        public ActionResult<ResponseWrapper> UpdateCartDetail(
            int cartDetailId, [FromBody] CartDetailModel cartDetail)
        {
            var exceptionResponse = HandleExceptions(() =>
            {
                _service.UpdateCartDetail(cartDetailId, cartDetail);
            });

            if (exceptionResponse != null) return exceptionResponse;

            return ok_get();
        }
    }
}
