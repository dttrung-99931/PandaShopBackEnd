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

        /// <summary>
        /// Get user cart 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("Cart")]
        public ActionResult<ResponseWrapper> GetCart()
        {
            return Handle(() => {
                int cartId = GetCartIdFromToken(User);
                if (cartId < 1)
                {
                    return notFound();
                }
                return Get(cartId);
            });
        }        

        /// <summary>
        /// Upsert cart
        /// - not existing => insert 
        /// - existing => update
        /// - productNum == 0 => delete
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UpsertCart")]
        public ActionResult<ResponseWrapper> UpsertCart([FromBody] CartDetailModel request)
        {
            CartDetailModel cartDetail = null;
            var exceptionResponse = HandleExceptions(() =>
            {
                cartDetail = Mapper.Map<CartDetailModel>(
                 _service.UpsertCart(request)
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

        [HttpDelete("DeleteMany")]
        public ActionResult<ResponseWrapper> DeleteMany([FromBody] DeleteCartItemsModel model)
        {
            var exceptionResponse = HandleExceptions(() =>
            {
                _service.DeleteCartItems(model);
            });

            if (exceptionResponse != null) return exceptionResponse;

            return ok_get();
        }
    }
}
