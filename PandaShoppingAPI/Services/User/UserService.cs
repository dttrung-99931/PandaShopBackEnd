using AutoMapper;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class UserService : BaseService<IUserRepo, User_, UserModel, UserFilter>, 
        IUserService
    {
        private readonly IShopRepo _shopRepo;
        public UserService(
            IUserRepo repo,
            IShopRepo shopRepo) : base(repo)
        {
            _shopRepo = shopRepo;
        }

        public void InsertShop(int userId, ShopModel shopModel)
        {
            var user = GetById(userId);
            if (user == null)
            {
                throw new KeyNotFoundException();
            }
            if (user.shopId != null)
            {
                throw new ConflictException();
            }
            
            var shopId = _shopRepo.Insert(Mapper.Map<Shop>(shopModel)).id;
            user.shopId = shopId;
            
            _repo.Update(user, user.id);
        }
    }
}
