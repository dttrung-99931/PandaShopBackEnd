using Microsoft.EntityFrameworkCore;
using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class DriverRepo : BaseRepo<Driver>, IDriverRepo
    {
        public DriverRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
