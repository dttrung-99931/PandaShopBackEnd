using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class CategoryService : BaseService<ICategoryRepo, Category, CategoryFilter>, ICategoryService
    {
        public CategoryService(ICategoryRepo repo) : base(repo)
        {
        }
    }
}
