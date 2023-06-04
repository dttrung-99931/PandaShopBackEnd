using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface IUserService : IBaseService<User_, UserModel, UserFilter>
    {
        void InsertShop(int userId, ShopModel shopModel);
        LoginResponse Login(LoginModel loginModel);
        int GetCartIdOfUser(int userId);
    }
}
