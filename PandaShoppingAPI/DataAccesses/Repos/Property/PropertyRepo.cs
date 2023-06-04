using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class PropertyRepo : BaseRepo<Property>, IPropertyRepo
    {
        public PropertyRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
