using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;

namespace PandaShoppingAPI.DataAccesses.Repos 
{
    public interface IFileRepo 
    {
        public string UploadFile(IFormFile file, FileType fileType, string fileName = null);
        public string GetFileUrl(IFormFile file, FileType fileType, string fileName);
        public void RemoveFile(FileType fileType, string fileName);
    }
}