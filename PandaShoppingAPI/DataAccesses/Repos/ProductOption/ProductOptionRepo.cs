using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class ProductOptionRepo : BaseRepo<ProductOption>, IProductOptionRepo
    {
        private readonly IProductOptionValueRepo _productOptionValueRepo;

        public ProductOptionRepo(IProductOptionValueRepo productOptionValueRepo, EcommerceDBContext dbContext) : base(dbContext)
        {
            _productOptionValueRepo = productOptionValueRepo;
        }

        public void InsertRange(int productId, List<ProductOptionRequest> productOptionModels)
        {
            productOptionModels.ForEach(
                model => Insert(productId, model));
        }

        public ProductOption Insert(int productId, ProductOptionRequest request)
        {
            var productOpt = Insert(new ProductOption()
                {
                    productId = productId,
                    name = request.name,
                    price = request.price
                }
            );
            _productOptionValueRepo.InsertRange(productOpt.id, request.properties);
            
            return productOpt;
        }

    }
}
