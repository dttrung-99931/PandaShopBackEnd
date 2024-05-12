using Microsoft.EntityFrameworkCore;
using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class UserRoleRepo : BaseRepo<UserRole>, IUserRoleRepo
    {
        public UserRoleRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
