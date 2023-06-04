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

        public void InsertRange(int productId, List<ProductOptionModel> productOptionModels)
        {
            productOptionModels.ForEach(
                model => Insert(productId, model));
        }

        private ProductOption Insert(int productId, ProductOptionModel model)
        {
            var productOpt = Insert(new ProductOption()
                {
                    productId = productId,
                    name = model.name,
                    price = model.price
                }
            );
            _productOptionValueRepo.InsertRange(productOpt.id, model.properties);
            
            return productOpt;
        }

    }
}
