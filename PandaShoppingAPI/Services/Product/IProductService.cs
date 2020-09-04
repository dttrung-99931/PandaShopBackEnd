using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface IProductService: IBaseService<Product, ProductModel, ProductFilter>
    {
    }
}
