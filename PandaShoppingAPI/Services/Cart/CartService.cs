using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class CartService : BaseService<ICartRepo, Cart, CartModel, CartFilter>, 
        ICartService
    {
        private readonly ICartDetailService _cartDetailService;
        private readonly IUserService _userService;

        public CartService(
            IUserService userService,
            ICartRepo repo,
            ICartDetailService cartDetailService) : base(repo)
        {
            _cartDetailService = cartDetailService;
            _userService = userService;
        }

        public CartDetail AddToCart(CartDetailModel request)
        {
            var cartId = _userService.GetCartIdOfUser(User.UserId);
            return _cartDetailService.Insert(cartId, request);
        }

        public void UpdateCartDetail(int cartDetailId, CartDetailModel cartDetail)
        {
            if (cartDetail.productNum >= 1)
            {
                _cartDetailService.Update(cartDetail, cartDetailId);
            } else
            {
                _cartDetailService.Delete(cartDetailId);
            }
        }
    }
}
