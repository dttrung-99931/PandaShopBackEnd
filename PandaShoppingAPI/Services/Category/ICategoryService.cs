using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using System.Collections.Generic;

namespace PandaShoppingAPI.Services
{
    public interface ICategoryService : IBaseService<Category, CategoryModel, CategoryFilter>
    {
        void InsertTemplateForCategory(int categoryId, TemplateModel model);
        List<int> GetRequiredPropertyIDsOfCategory(int categoryId);
        List<Category> GetCategorySuggesstions(string q, int suggestionNum);
        TemplateResponseModel GetTemplateOfCate(int categoryId);
    }
}
