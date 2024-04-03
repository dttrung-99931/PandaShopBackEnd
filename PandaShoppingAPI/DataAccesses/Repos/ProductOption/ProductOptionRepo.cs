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
            List<ProductOptionRequest> updated = new List<ProductOptionRequest>();
            List<ProductOptionRequest> inserted = new List<ProductOptionRequest>();
            List<ProductOptionRequest> deleted = new List<ProductOptionRequest>();
            productOptions.ForEach((ProductOptionRequest optionReq) =>
            {
                if (options.Any((option) => optionReq.id == option.id))
                {
                    updated.Add(optionReq);
                } 
                else if (optionReq.id < 0) 
                {
                    inserted.Add(optionReq);
                } 
                else
                {
                    deleted.Add(optionReq);
                }
            });
            
            if (inserted.Count > 0)
            {
                InsertRange(productId, inserted);
            }

            if (deleted.Count > 0)
            {
                List<int> deleteIds = deleted.Select((optionReq) => optionReq.id).ToList();
                DeleteIf((option) => deleteIds.Contains(option.id));
            }

            if (updated.Count > 0)
            {
                UpdateRange(productId, updated);
            }
        }

        public void UpdateRange(int productId, List<ProductOptionRequest> productOptions)
        {
            List<int> ids = productOptions.Select((option) => option.id).ToList();
            List<ProductOption> updated = Where((option) => ids.Contains(option.id)).ToList();
            Dictionary<int, ProductOptionRequest> optionReqsMap = productOptions.ToDictionary((optionReq) => optionReq.id, (optionReq) => optionReq);
            updated.ForEach((option) =>
            {
                ProductOptionRequest optionReq = optionReqsMap[option.id];
                option.ProductOptionValue = Mapper.Map<List<ProductOptionValue>>(optionReq.properties);
                option.price = optionReq.price;
                option.name = optionReq.name;
            });
            UpdateRange(updated);
        }
    }
}
