using AutoMapper;
using Castle.Core.Internal;
using Castle.DynamicProxy;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Models.Base;
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
        private readonly IProductDeliveryMethodRepo _prodDeliveryMethodRepo;
        private readonly IDeliveryMethodRepo _deliveryMethodRepo;

        public ProductService(
            IProductRepo repo,
            IProductOptionRepo productOptionRepo,
            IProductPropertyValueRepo productPropertyValueRepo,
            IImageService imageService, 
            ICategoryService categoryService,
            IProductDeliveryMethodRepo prodDeliveryMethodRepo,
            IDeliveryMethodRepo deliveryMethodRepo
            ) : base(repo)
        {
            _productOptionRepo = productOptionRepo;
            _productPropertyValueRepo = productPropertyValueRepo;
            _categoryService = categoryService;
            _imageService = imageService;
            _prodDeliveryMethodRepo = prodDeliveryMethodRepo;
            _deliveryMethodRepo = deliveryMethodRepo;
        }

        public void DeletePropertyValues(int id, List<int> propertyValueIDs)
        {
            var product = GetById(id);
            if (product == null)
            {
                throw new NotFoundException("Product" , id);
            }

            var requiredPropertyIDs =
                _categoryService.GetRequiredPropertyIDsOfCategory(product.categoryId);

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

            // Temporarily, Default set all delivery methods to a new created product
            List<DeliveryMethod> allMethods = _deliveryMethodRepo.GetAll();
            _prodDeliveryMethodRepo.InsertRange(
                allMethods.Select((method) => new ProductDeliveryMethod()
            {
                productId = product.id,
                deliveryMethodId = method.id,
            }).ToList());

            return product;
        }

        protected override void ValidateInsert(ProductModel requestModel)
        {
            base.ValidateInsert(requestModel);
            if (requestModel.productOptions.IsNullOrEmpty())
            {
                throw new BadRequestException("Required at least 1 product option to present product number");
            }
        }

        public override void Update(ProductModel requestModel, object id)
        {
            Product product = GetById(id);
            product.name = requestModel.name;
            product.description = requestModel.description;
            product.sellingNum = requestModel.sellingNum;
            product.categoryId = requestModel.categoryId;
            product.shopId = requestModel.shopId;
            product.addressId = requestModel.addressId;
            _repo.Update(product, id);

            List<ProductPropertyValue> properties = Mapper.Map<List<ProductPropertyValue>>(requestModel.properties);
            properties.ForEach(prop => prop.productId = product.id);
            _productPropertyValueRepo.ReplaceRange(product.ProductPropertyValue, properties);

            _productOptionRepo.UpsertRange((int)id, requestModel.productOptions);
            // TODO: update what else?
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

        public IDsResponseModel InsertPropertyValues(int productId, List<PropertyValueRequest> propertyValueReqs)
        {
            List<ProductPropertyValue> propertyValues = Mapper.Map<List<ProductPropertyValue>>(propertyValueReqs);
            propertyValues.ForEach(propVal => propVal.productId = productId);
            _productPropertyValueRepo.InsertRange(propertyValues);
            return new IDsResponseModel(propertyValues.Select(p => p.id).ToList());
        }

        public override IQueryable<Product> Fill(ProductFilter filter)
        {
            var filledProducts = base.Fill(filter);

            filledProducts = FillByCategory(filledProducts, filter);
            
            filledProducts = FillByPrice(filledProducts, filter);
            
            filledProducts = FillByProvinceOrCityCode(filledProducts, filter);

            filledProducts = FillByShopId(filledProducts, filter);

            filledProducts = FillByQ(filledProducts, filter);
            
            filledProducts = OrderBy(filledProducts, filter);
            
            return filledProducts;
        }

        private IQueryable<Product> FillByQ(
            IQueryable<Product> filledProducts, 
            ProductFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.q))
            {
                var unescapedQ = filter.UnescapeQ();
                
                return filledProducts.Where(
                    product => product.name.Contains(unescapedQ)
                    || product.category.name.Contains(unescapedQ));
            }
            return filledProducts;
        }

        private IQueryable<Product> FillByProvinceOrCityCode(
            IQueryable<Product> filledProducts, 
            ProductFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.provinceOrCityCode))
            {
                return filledProducts
                    .Where(product => product.address.provinceOrCityCode == 
                                      filter.provinceOrCityCode);
            }
            return filledProducts;
        }

        private IQueryable<Product> FillByShopId(
            IQueryable<Product> filledProducts,
            ProductFilter filter)
        {
            if (filter.shopId != null)
            {
                return filledProducts
                    .Where(product => product.shopId == filter.shopId);
            }
            return filledProducts;
        }


        private IQueryable<Product> OrderBy(
            IQueryable<Product> products,
            ProductFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.orderBy))
            {
                if (filter.orderBy.Equals(ProductFilter.ASC))
                {
                    products = products.OrderBy(
                        product => product.ProductOption.First().price
                    );
                }
                else if (filter.orderBy.Equals(ProductFilter.DESC))
                {
                    products = products.OrderByDescending(
                        product => product.ProductOption.First().price
                    );  
                }
                else throw new BadRequestException("Invalid 'orderBy' param");
            }
            
            return products;
        }

        private IQueryable<Product> FillByPrice(
            IQueryable<Product> products, 
            ProductFilter filter)
        {
            if (filter.fromPrice != null)
            {
                products = products
                    .Where(product =>
                        product.ProductOption.Count > 0
                        && product.ProductOption.First().price >= filter.fromPrice);
            }

            if (filter.toPrice != null)
            {
                products = products
                    .Where(product =>
                        product.ProductOption.Count > 0
                        && product.ProductOption.First().price <= filter.toPrice);
            }

            return products;
        }

        private IQueryable<Product> FillByCategory(
            IQueryable<Product> products, 
            ProductFilter filter)
        {
            if (filter.categoryIdLV3 != null)
            {
                products = products
                    .Where(product => product.categoryId == filter.categoryIdLV3);
            }

            if (filter.categoryIdLV2 != null)
            {
                products = products
                    .Where(product => product.category.parentId == filter.categoryIdLV2);
            }

            if (filter.categoryIdLV1 != null)
            {
                products = products
                    .Where(product => product.category.parentId != null
                            && product.category.parent.parentId == filter.categoryIdLV1);
            }

            return products;
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
                suggestion.products = Mapper.Map<List<ShortProductResponse>>(
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

        public void UpdateProductOptions(int id, List<ProductOptionRequest> options)
        {
            //_productOptionRepo.UpdateRange
            //_imageService.UpdateProductImages(id, images);

        }

        public IDResponseModel CreateProductOption(int productId, ProductOptionRequest option)
        {
            ProductOption entity = _productOptionRepo.Insert(productId, option);
            return Mapper.Map<IDResponseModel>(entity);
        }

        public void DeleteProductOptions(int productId, List<int> productOptionIDs)
        {
            _productOptionRepo.DeleteIf(
                option => option.productId == productId && productOptionIDs.Contains(option.id)
            );
        }

        public void UpdateProduct(int productId, UpdateProductModel updateModel)
        {
            _repo.Update(productId, (product) =>
            {
                product.name = updateModel.name;
                product.description = updateModel.description;
                product.categoryId = updateModel.categoryId;
                product.shopId = updateModel.shopId;
            });
        }
    }
}
