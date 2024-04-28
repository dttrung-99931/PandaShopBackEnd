using AutoMapper;
using Castle.Core.Internal;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        public void UpsertRange(int productId, List<ProductOptionRequest> productOptions)
        {
            List<ProductOption> options = Where((option) => productId == option.productId).ToList();

            List<ProductOptionRequest> updated = productOptions
                .IntersectBy(options.Select((entity) => entity.id), (optionReq) => optionReq.id)
                .ToList();
            List<ProductOptionRequest> inserted = productOptions.Except(updated).ToList();
            List<int> deletedIds = options
                .ExceptBy(productOptions.Select((optionReq) => optionReq.id), (option) => option.id)
                .Select((option) => option.id)
                .ToList();
            
            if (inserted.Count > 0)
            {
                InsertRange(productId, inserted);
            }
            if (deletedIds.Count > 0)
            {
                DeleteIf((option) => deletedIds.Contains(option.id));
            }
            if (updated.Count > 0)
            {
                UpdateRange(productId, updated);
            }
        }

        public void UpdateRange(int productId, List<ProductOptionRequest> productOptions)
        {
            List<int> ids = productOptions.Select((option) => option.id).ToList();
            List<ProductOption> toUpdate = Where((option) => ids.Contains(option.id)).ToList();
            Dictionary<int, ProductOptionRequest> optionReqsMap = productOptions.ToDictionary((optionReq) => optionReq.id, (optionReq) => optionReq);
            toUpdate.ForEach((option) =>
            {
                ProductOptionRequest optionReq = optionReqsMap[option.id];
                _productOptionValueRepo.ReplaceRange(
                    option.ProductOptionValue,
                    optionReq.properties.Select(
                        (prop) => new ProductOptionValue()
                        {
                            productOptionId = option.id,
                            propertyId = prop.propertyId,
                            value = prop.value
                        }
                    )
                );
                option.price = optionReq.price;
                option.name = optionReq.name;
            });
            UpdateRange(toUpdate);
        }
    }
}
