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

        public void DeleteMany(int cartId, DeleteCartItemsModel model)
        {
            _repo.DeleteIf(detail => detail.cartId == cartId && model.itemIds.Contains(detail.id));
        }

        public CartDetail Upsert(int cartId, CartDetailModel request)
        {
            CartDetail detail =  _repo
                .Where((detail) => detail.cartId == cartId && detail.productOptionId == request.productOptionId)
                .FirstOrDefault();

            if (detail == null)
            {
                var cartDetail = Mapper.Map<CartDetail>(request);
                cartDetail.cartId = cartId;
                return _repo.Insert(cartDetail);
            }

            if (request.productNum > 0)
            {
                detail.productNum = request.productNum;
                _repo.Update(detail, detail.id);
                return detail;
            }

            _repo.Delete(detail.id);
            return detail;
        }

    }
}
