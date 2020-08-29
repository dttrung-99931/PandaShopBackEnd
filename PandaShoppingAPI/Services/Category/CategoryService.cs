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

        public override IQueryable<Category> Fill(CategoryFilter filter)
        {
            var filledCategories = base.Fill(filter);
            if (filter.parentId != null)
            {
                filledCategories = filledCategories
                    .Where(category => category.parentId == filter.parentId);
            }

            if (filter.level != null)
            {
                filledCategories = filledCategories
                    .Where(category => category.level == filter.level);
            }
            
            if (filter.q != null)
            {
                var unescapedQ = filter.UnescapeQ();

                filledCategories = filledCategories
                    .Where(category => category.name.Contains(unescapedQ));
            }

            return filledCategories;
        }
    }
}
