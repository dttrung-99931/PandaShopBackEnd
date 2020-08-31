using AutoMapper;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace PandaShoppingAPI.Services
{
    public class ImageService : BaseService<IImageRepo, Image, ImageModel, ImageFilter>, 
        IImageService
    {
        private readonly ConfigUtil _configUtil;
        
        public ImageService(IImageRepo repo, ConfigUtil configUtil) : base(repo)
        {
            _configUtil = configUtil;
        }

        public Image InsertCategoryImg(string based64Img)
        {
            return InsertImg(based64Img, _configUtil.GetCategoryImgDirPath());
        }

        public Image InsertImg(string based64Img, string storeDirPath)
        {
            var imgFileName = UploadBase64.UploadBased64Img(
                    based64Img, storeDirPath
            );

            Image image = new Image()
            {
                fileName = imgFileName
            };

            return _repo.Insert(image);
        }

        /***
         * Ignore to use this func
         * 
         * Use specified DeleteXXX instead, for ex: DeleteCategoryImg 
         */
        public override void Delete(object id)
        {
            throw new Exception("Use specified DeleteXXX instead, for ex: DeleteCategoryImg");
        }

        public void DeleteCategoryImg(int imageId)
        {
            DeleteImg(imageId, _configUtil.GetCategoryImgDirPath());
        }

        private void DeleteImg(int imgId, string imgStoreDirPath)
        {
            var deletedImg = GetById(imgId);

            if (deletedImg != null)
            {
                DeleteImgFile(deletedImg, imgStoreDirPath);
                
                _repo.Delete(imgId);                   
            } else throw new Exception("Image not found to delete, id = " + imgId);
        }

        private void DeleteImgFile(Image img, string imgStoreDirPath)
        {
            string deletedImgPath = Path.Combine(
                    imgStoreDirPath, img.fileName);
            try
            {
                if (!string.IsNullOrEmpty(deletedImgPath))
                    File.Delete(deletedImgPath);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in Delete file img: " + e.Message);
            }
        }

        //public void InsertMaintenanceImages(int maintenanceId, List<ImageModel> imgs)
        //{
        //    foreach (var imgModel in imgs)
        //    {
        //        if (!string.IsNullOrEmpty(imgModel.based64Img))
        //        {
        //            var imgFileName = UploadBase64.UploadBased64Img(
        //                        imgModel.based64Img,
        //                        _configUtil.GetMaintenanceImgDirPath()
        //            );

        //            Image image = new Image()
        //            {
        //                maintenance_id = maintenanceId,
        //                img_file_name = imgFileName,
        //                description = imgModel.description   
        //            };

        //            _repo.Insert(image);
        //        }
        //        else throw new Exception("Add maintenance image without base64Image");   
        //    }

        //}

        public void DeleteRange(List<int> ids)
        {
            foreach (var id in ids)
            {
                Delete(id);
            }
        }

        //public void UpdateRange(List<ImageModel> updatedImgs)
        //{
        //    foreach (var imgModel in updatedImgs)
        //    {
        //        var originImg = _repo.GetById(imgModel.id);
        //        if (!string.IsNullOrEmpty(imgModel.based64Img))
        //        {
        //            Delete(imgModel.id);
        //            if (originImg.maintenance_id != null)
        //            {
        //                InsertMaintenanceImages((int)originImg.maintenance_id,
        //                 new List<ImageModel> { imgModel });
        //            }
        //        }
        //        else if (originImg.description != imgModel.description)
        //        {
        //            originImg.description = imgModel.description;
        //            _repo.Update(originImg, originImg.id);
        //        }
        //    }
        //}
    }
}