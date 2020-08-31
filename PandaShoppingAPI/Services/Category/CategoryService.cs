using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class CategoryService : BaseService<ICategoryRepo, Category, CategoryModel, CategoryFilter>, 
        ICategoryService
    {
        private readonly IImageService _imageService;
        public CategoryService(ICategoryRepo repo, IImageService imageService) : base(repo)
        {
            _imageService = imageService;
        }

        /***
         * Insert new category
         * 
         * If the @param requestModel contains based64 image
         * then insert the image first, then assign the inserted image id 
         * for @param requestModel.imageId 
         */
        public override Category Insert(CategoryModel requestModel)
        {
            if (!string.IsNullOrEmpty(requestModel.based64Img))
            {
                var imgId = _imageService.InsertCategoryImg(requestModel.based64Img).id;
                requestModel.imageId = imgId;
            }
            return base.Insert(requestModel);
        }

        /***
         * Update category 
         * 
         * If @param requestModel.based64Img is not empty 
         * then create new image for the updated category 
         * then update the category 
         * then delete the old image category
         */
        public override void Update(CategoryModel requestModel, object id)
        {
            var oldImageId = GetById(id).imageId;
            if (!string.IsNullOrEmpty(requestModel.based64Img))
            {
                var imgId = _imageService.InsertCategoryImg(requestModel.based64Img).id;
                requestModel.imageId = imgId;
            }
            base.Update(requestModel, id);

            if (oldImageId != null)
            {
                _imageService.DeleteCategoryImg((int)oldImageId);
            }
        }

        public override IQueryable<Category> Fill(CategoryFilter filter)
        {
            var filledCategories = base.Fill(filter);
            if (filter.parentId != null)
            {
                filledCategories = filledCategories
                    .Where(category => category.parentId == filter.parentId);
            }

            if (filter.level != null)
            {
                filledCategories = filledCategories
                    .Where(category => category.level == filter.level);
            }
            
            if (filter.q != null)
            {
                var unescapedQ = filter.UnescapeQ();

                filledCategories = filledCategories
                    .Where(category => category.name.Contains(unescapedQ));
            }

            return filledCategories;
        }
    }
}
