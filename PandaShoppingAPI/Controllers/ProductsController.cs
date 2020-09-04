using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.Controllers.Base;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;

namespace PandaShoppingAPI.Controllers
{
    [Route("v1/[controller]")]
    public class ProductsController : CrudApiController<Product, ProductModel,
            ProductResponseModel, IProductService, ProductFilter>
    {
        
        public ProductsController(IProductService service) : base(service)
        {
        }
    }
}
