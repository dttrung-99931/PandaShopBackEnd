using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface IUserService : IBaseService<User_, UserModel, UserFilter>
    {
        Shop InsertShop(int userId, ShopModel shopModel);
        User_ InsertDriver(DriverModel model);
        LoginResponse Login(LoginModel loginModel);
        int GetCartIdOfUser(int userId);
    }
}
