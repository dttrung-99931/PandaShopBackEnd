using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class ProductService : BaseService<IProductRepo, Product, ProductModel, ProductFilter>,
        IProductService
    {
        public ProductService(IProductRepo repo) : base(repo)
        {
        }
    }
}
