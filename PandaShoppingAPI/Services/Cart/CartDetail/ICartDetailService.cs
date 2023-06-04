using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface ICartDetailService : IBaseService<CartDetail, CartDetailModel, Filter>
    {
        CartDetail Insert(int cartId, CartDetailModel request);
    }
}
