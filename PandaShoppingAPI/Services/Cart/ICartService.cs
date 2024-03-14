using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface ICartService : IBaseService<Cart, CartModel, CartFilter>
    {
        CartDetail UpsertCart(CartDetailModel request);
        void UpdateCartDetail(int cartDetailId, CartDetailModel cartDetail);
        void DeleteCartItems(DeleteCartItemsModel model);
    }
}
