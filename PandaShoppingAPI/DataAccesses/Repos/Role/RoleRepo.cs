using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class RoleRepo : BaseRepo<Role>, IRoleRepo
    {
        public RoleRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
