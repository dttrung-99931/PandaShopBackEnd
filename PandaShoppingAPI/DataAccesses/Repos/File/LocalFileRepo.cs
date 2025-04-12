using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class LocalFileRepo : IFileRepo
    {
        private readonly FileConfig _configUtil;

        public LocalFileRepo(FileConfig configUtil)
        {
            _configUtil = configUtil;
        }

        public string GetFileUrl(IFormFile file, FileType fileType, string fileName)
        {
            string requestPath = _configUtil.GetRequestPath(fileType);

            return Path.Combine(requestPath, fileName);
        }

        public string UploadFile(IFormFile file, FileType fileType, string fileName)
        {
            string dirPath = _configUtil.GetDirPath(fileType);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            if (string.IsNullOrEmpty(fileName))
            {
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            }

            string filePath = Path.Combine(dirPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }

        public void RemoveFile(FileType fileType, string fileName)
        {
            string dirPath = _configUtil.GetDirPath(fileType);
            string filePath = Path.Combine(dirPath, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}