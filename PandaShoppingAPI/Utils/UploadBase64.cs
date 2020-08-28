using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace PandaShoppingAPI.Utils
{
    public class UploadBase64
    {
        public static List<string> Upload(string[] imagesName, string[] imagesContent, string pathToDir)
        {
            if (!Directory.Exists(pathToDir))
            {
                Directory.CreateDirectory(pathToDir);
            }
            List<string> uploadedImages = new List<string>();
            for (int i = 0; i < imagesName.Length; i++)
            {
                try
                {
                    var fileName = Guid.NewGuid() + imagesName[i];
                    string filePath = pathToDir + Path.GetFileName(fileName);
                    var bytesContent = Convert.FromBase64String(imagesContent[i]);
                    File.WriteAllBytes(filePath, bytesContent);
                    uploadedImages.Add(fileName);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return uploadedImages;
        }

        internal static string UploadBased64Img(string based64Img, string storeDirPath)
        {
            if (!Directory.Exists(storeDirPath))
            {
                Directory.CreateDirectory(storeDirPath);
            }
            try
            {
                var bytesContent = Convert.FromBase64String(based64Img);
                var format = ImgUtil.GetImageFormat(bytesContent);
                if (format != ImgUtil.ImageFormat.unknown)
                {
                    var UUIDFileName = Guid.NewGuid() + "." + format;
                    var filePath = Path.Combine(storeDirPath, UUIDFileName);
                    File.WriteAllBytes(filePath, bytesContent);
                    return UUIDFileName;
                }
                else throw new Exception("Unsupported image format");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
