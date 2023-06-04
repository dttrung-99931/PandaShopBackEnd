using Microsoft.EntityFrameworkCore;
using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class UserRepo: BaseRepo<User_>, IUserRepo
    {
        private readonly ICartRepo _cartRepo;

        public UserRepo(ICartRepo cartRepo, EcommerceDBContext dbContext): base(dbContext)
        {
            _cartRepo = cartRepo;
        }

        /***
         * Insert a new cart then insert the user with the cart.id
         */
        public override User_ Insert(User_ entity)
        {
            var cartId = _cartRepo.Insert(new Cart()).id;
            entity.cartId = cartId;
            return base.Insert(entity);
        }

        public override void Update(User_ entityToUpdate, object id)
        {
            Update(entityToUpdate, id, 
                change =>
                {
                    change.Property(user => user.createdAt).IsModified = false;
                    change.Property(user => user.cartId).IsModified = false;
                }
            );
        }
    }
}
