using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Services
{
    public class ProductInventoryService: IProductInventoryService
    {
        private readonly IProductBatchInventoryRepo _batchInventoryRepo;
        private readonly IProductRepo _productRepo;
        public ProductInventoryService(IProductBatchInventoryRepo repo, IProductRepo productRepo) 
        {
            _batchInventoryRepo = repo;
            _productRepo = productRepo;
        }

        public ProductInventoryResponse GetProductInventory(int productId)
        {
            Product product = _productRepo.GetById(productId);

            List<ProductOptionInvetoryResponse> optionInvetories =  _batchInventoryRepo
                .Where((ProductBatchInventory inventory) => inventory.productBatch.productOption.productId == productId)
                // TODO: optimize
                .AsEnumerable()
                .GroupBy((ProductBatchInventory inventory) => inventory.productBatch.productOption)
                .Select((group) =>
                 new ProductOptionInvetoryResponse() {
                    productOption = Mapper.Map<ProductOptionResponse>(group.Key),
                    number = group.Sum((batch) => batch.remainingNumber),
                })
                .ToList();

            return new ProductInventoryResponse
            {
                product = Mapper.Map<ShortProductResponse>(product),
                optionInventories = optionInvetories,
            };
        }
    }
}
