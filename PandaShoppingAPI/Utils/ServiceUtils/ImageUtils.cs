using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.DataAccesses.EF;
using System.IO;

namespace PandaShoppingAPI.Utils.ServiceUtils
{
    public class ImageUtils
    {
        public static string BuildProductImageLink(IConfiguration config, ProductImage productImage)
        {
            return Path.Combine(
                config["Path:ProductImgEndPoint"],
                productImage.image.fileName
            );
        }

    }
}
