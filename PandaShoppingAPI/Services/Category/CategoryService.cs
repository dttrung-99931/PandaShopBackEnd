using AutoMapper;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;
using PandaShoppingAPI.Utils.Extentions;
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
        private readonly ITemplateService _templateService;
        public CategoryService(
            ICategoryRepo repo, 
            IImageService imageService,
            ITemplateService templateService) : base(repo)
        {
            _imageService = imageService;
            _templateService = templateService;
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

        public void InsertTemplateForCategory(int categoryId, TemplateModel model)
        {
            var category = GetById(categoryId);
            if (category == null)
            {
                throw new KeyNotFoundException();
            }

            if (category.templateId != null)
            {
                throw new ConflictException();
            }

            var templateId = _templateService.Insert(model).id;

            category.templateId = templateId;

            _repo.Update(category, category.id);
        }

        public List<int> GetRequiredPropertyIDsOfCategory(int categoryId)
        {
            var category = GetById(categoryId);

            // Category has no property template => Has no required proerpties
            if (category?.templateId == null)
            {
                return new List<int>();
            }

            return _templateService.GetRequiredPropertyIDs((int)category.templateId);
        }

        public List<Category> GetCategorySuggesstions(string q, int suggestionNum)
        {
            return _repo.Where(category => category.name.Contains(q.Unescaped()))
                .Take(suggestionNum)
                .ToList();
        }

        /// Return template of category or first cate parent's template
        /// Return null if the category and its parents don't have a template
        /// TODO: Merge template of parents
        public TemplateResponseModel GetTemplateOfCate(int categoryId)
        {
            Category category = GetById(categoryId);
            Template template = category?.template;
            while (template == null && category?.parentId != null)
            {
                category = category.parent;
                template = category.template;
            }
            if (template != null)
            {
                return Mapper.Map<TemplateResponseModel>(template);
            } else
            {
                return null;
            }
        }
    }
}
