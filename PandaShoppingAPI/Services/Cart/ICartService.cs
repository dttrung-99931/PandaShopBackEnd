using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface ICartService : IBaseService<Cart, CartModel, CartFilter>
    {
        CartDetail AddToCart(CartDetailModel request);
        void UpdateCartDetail(int cartDetailId, CartDetailModel cartDetail);
    }
}
