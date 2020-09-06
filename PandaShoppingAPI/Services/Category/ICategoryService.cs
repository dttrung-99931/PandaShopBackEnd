using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using System.Collections.Generic;

namespace PandaShoppingAPI.Services
{
    public interface ICategoryService : IBaseService<Category, CategoryModel, CategoryFilter>
    {
        void InsertTemplateForCategory(int categoryId, TemplateModel model);
        List<int> GetRequiredPropertyIDs(int categoryId);
    }
}
