﻿using AutoMapper;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils.Exceptions;
using PandaShoppingAPI.Utils.Extentions;
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
        private readonly IImageService _imageService;

        public ProductService(
            IProductRepo repo,
            IProductOptionRepo productOptionRepo,
            IProductPropertyValueRepo productPropertyValueRepo,
            IImageService imageService, 
            ICategoryService categoryService) : base(repo)
        {
            _productOptionRepo = productOptionRepo;
            _productPropertyValueRepo = productPropertyValueRepo;
            _categoryService = categoryService;
            _imageService = imageService;
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

            if (filter.categoryIdLV3 != null)
            {
                filledProducts = filledProducts
                    .Where(product => product.categoryId == filter.categoryIdLV3);
            }

            if (filter.categoryIdLV2 != null)
            {
                filledProducts = filledProducts
                    .Where(product => product.category.parentId == filter.categoryIdLV2);
            }

            if (filter.categoryIdLV1 != null)
            {
                filledProducts = filledProducts
                    .Where(product => product.category.parentId != null
                            && product.category.parent.parentId == filter.categoryIdLV1);
            }

            if (!string.IsNullOrEmpty(filter.q))
            {
                var unescapedQ = Uri.UnescapeDataString(filter.q);
                filledProducts = filledProducts.Where(
                    product => product.name.Contains(unescapedQ)
                    || product.category.name.Contains(unescapedQ));
            }

            return filledProducts;
        }

        public List<ProductImage> InsertImages(int productId, List<ProductImageRequest> images)
        {
            return _imageService.InsertProductImages(productId, images);
        }

        public void UpdateImages(int productId, List<ProductImageRequest> images)
        {
            _imageService.UpdateProductImages(productId, images);
        }

        /***
         * Get search @param suggestionNum suggestions based on @param q
         * 
         * First, Find category suggestions. If the found suggestions 
         * number = @param suggestionNum then @return only suggestions with the categories.
         * Otherwise find product suggestions to satisfy @param suggestionNum suggestions
         */
        public SearchSuggestion GetSearchSuggestions(SearchSuggestionRequest requesModel)
        {
            var suggestion = new SearchSuggestion();

            if (requesModel.categoryId == null)
            {
                suggestion.categories = Mapper.Map<List<CategoryResponse>>(
                    _categoryService.GetCategorySuggesstions(
                        requesModel.q,
                        requesModel.suggestionNum)
                );
            }

            if (suggestion.categories.Count < requesModel.suggestionNum)
            {
                suggestion.products = Mapper.Map<List<ThumbProductResponse>>(
                    GetProductSuggesstions(
                        requesModel.q, 
                        requesModel.suggestionNum - suggestion.categories.Count,
                        requesModel.categoryId)
                );
            }

            return suggestion;
        }

        private List<Product> GetProductSuggesstions(
            string q,
            int suggesstionNum = 10, 
            int? categoryId = null)
        {
            var products = _repo.GetIQueryable();

            if (categoryId != null)
            {
                products = products
                    .Where(product => product.categoryId == categoryId
                           ||
                           product.category.parentId != null &&
                            (
                                    product.category.parentId == categoryId
                                    ||
                                    (product.category.parent.parentId != null &&
                                     product.category.parent.parentId == categoryId)
                            )
                    );
            }

            return products.Where(
                    product => product.name.Contains(q.Unescaped()))
                .Take(suggesstionNum)
                .ToList();
        }
    }
}
