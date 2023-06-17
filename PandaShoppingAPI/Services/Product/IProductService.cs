using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Models.Base;
using System.Collections.Generic;

namespace PandaShoppingAPI.Services
{
    public interface IProductService : IBaseService<Product, ProductModel, ProductFilter>
    {
        void UpdatePropertyValue(int productId, PropertyValueRequest propertyValueReq);
        void UpdatePropertyValues(int productId, List<PropertyValueRequest> propertyValueReqs);
        void DeletePropertyValues(int id, List<int> propertyValueIDs);
        List<ProductImage> InsertImages(int productId, List<ProductImageRequest> images);
        void UpdateImages(int productId, List<ProductImageRequest> images);
        SearchSuggestion GetSearchSuggestions(SearchSuggestionRequest requesModel);
        void UpdateProductOptions(int productId, List<ProductOptionRequest> options);
        IdResponseModel CreateProductOption(int productId, ProductOptionRequest option);
        void DeleteProductOptions(int productId, List<int> productOptionIDs);
    }
}
