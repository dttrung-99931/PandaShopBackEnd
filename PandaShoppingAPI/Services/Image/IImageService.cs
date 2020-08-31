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
        //void UpdateRange(List<ImageModel> updatedImgs);
    }
}