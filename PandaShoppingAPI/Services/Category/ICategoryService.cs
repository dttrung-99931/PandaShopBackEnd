using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface ICategoryService: IBaseService<Category, CategoryModel, CategoryFilter>
    {
    }
}
