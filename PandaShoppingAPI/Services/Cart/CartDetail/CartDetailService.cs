using AutoMapper;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class CartDetailService : BaseService<ICartDetailRepo,
        CartDetail, CartDetailModel, Filter>,
        ICartDetailService
    {
        public CartDetailService(ICartDetailRepo repo) : base(repo)
        {
        }

        public CartDetail Insert(int cartId, CartDetailModel request)
        {
            var cartDetail = Mapper.Map<CartDetail>(request);
            cartDetail.cartId = cartId;
            return _repo.Insert(cartDetail);
        }

    }
}
