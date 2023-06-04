using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class TemplateRepo : BaseRepo<Template>, ITemplateRepo
    {
        public TemplateRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
