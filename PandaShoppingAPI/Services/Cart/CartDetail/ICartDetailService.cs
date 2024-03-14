using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface ICartDetailService : IBaseService<CartDetail, CartDetailModel, Filter>
    {
        void DeleteMany(int cartId, DeleteCartItemsModel model);
        CartDetail Upsert(int cartId, CartDetailModel request);
    }
}
