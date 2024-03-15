using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using System.Collections.Generic;

namespace PandaShoppingAPI.Services
{
    public interface IImageService : IBaseService<Image, ImageModel, ImageFilter>
    {
        Image InsertCategoryImg(string based64Img);
        //void InsertMaintenanceImages(int maintenanceId, List<ImageModel> imgs);
        void DeleteRange(List<int> ids);
        void DeleteCategoryImg(int oldImageId);
        List<ProductImage> InsertProductImages(int prodcutId, List<ProductImageRequest> images);
        void UpdateProductImages(int productId, List<ProductImageRequest> images);
        //void UpdateRange(List<ImageModel> updatedImgs);
        string BuildProductImageLink(ProductImage image);
    }
}