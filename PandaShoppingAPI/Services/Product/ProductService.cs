﻿using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class ProductService : BaseService<IProductRepo, Product, ProductModel, ProductFilter>,
        IProductService
    {
        private readonly IProductOptionRepo _productOptionRepo;
        private readonly IProductPropertyValueRepo _productPropertyValueRepo;
        private readonly ICategoryService _categoryService;

        public ProductService(
            IProductRepo repo,
            IProductOptionRepo productOptionRepo,
            IProductPropertyValueRepo productPropertyValueRepo,
            ICategoryService categoryService) : base(repo)
        {
            _productOptionRepo = productOptionRepo;
            _productPropertyValueRepo = productPropertyValueRepo;
            _categoryService = categoryService;
        }

        public void DeletePropertyValues(int id, List<int> propertyValueIDs)
        {
            var product = GetById(id);
            if (product == null)
            {
                throw new NotFoundException("Product" , id);
            }

            var requiredPropertyIDs =
                _categoryService.GetRequiredPropertyIDs(product.categoryId);

            var acceptedDeletedPropertyValueIds = new List<object>();

            foreach (var pvID in propertyValueIDs)
            {
                var propertyValue = _productPropertyValueRepo.GetById(pvID);
                
                if (propertyValue == null)
                {
                    throw NotFoundException.NotFound("Product property", pvID);
                }
                
                if (propertyValue.productId != id)
                {
                    throw NotFoundException.NotContain("Product", id, "Product property", pvID);
                }

                if (requiredPropertyIDs.Contains(propertyValue.propertyId))
                {
                    throw new ForbiddenException("Delete", "Product property", pvID);
                }

                acceptedDeletedPropertyValueIds.Add(pvID);
            }

            _productPropertyValueRepo.DeleteRange(acceptedDeletedPropertyValueIds);
        }

        public override Product Insert(ProductModel requestModel)
        {
            var product =  base.Insert(requestModel);

            _productPropertyValueRepo.InsertRange(product.id, requestModel.properties);

            _productOptionRepo.InsertRange(product.id, requestModel.productOptions);

            return product;
        }

        public void UpdatePropertyValue(int productId, PropertyValueRequest propertyValueReq)
        {
            if (GetById(productId) == null)
            {
                throw new KeyNotFoundException("Product with id " + productId + " not found");
            }

            _productPropertyValueRepo.Update(
                propertyValueReq.id, 
                updater => updater.value = propertyValueReq.value);
        }

        public void UpdatePropertyValues(int productId, List<PropertyValueRequest> propertyValueReqs)
        {
            propertyValueReqs.ForEach(
                valueReq => UpdatePropertyValue(productId, valueReq));
        }

        public override IQueryable<Product> Fill(ProductFilter filter)
        {
            var filledProducts = base.Fill(filter);

            if (!string.IsNullOrEmpty(filter.q))
            {
                var unescapedQ = Uri.UnescapeDataString(filter.q);
                filledProducts = filledProducts.Where(
                    product => product.name.Contains(unescapedQ)
                    || product.category.name.Contains(unescapedQ));
            }
            return filledProducts;
        }
    }
}