using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.Controllers.Base;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;

namespace PandaShoppingAPI.Controllers
{
    [Route("v1/[controller]")]
    public class CategoriesController : CrudApiController<Category, CategoryModel,
            CategoryResponseModel, ICategoryService, CategoryFilter>
    {
        public CategoriesController(ICategoryService service) : base(service)
        {
        }
    }
}
