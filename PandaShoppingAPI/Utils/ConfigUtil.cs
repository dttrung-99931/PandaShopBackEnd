using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Utils
{
    public class ConfigUtil
    {
        private readonly IConfiguration _config;

        public ConfigUtil(IConfiguration config)
        {
            _config = config;
        }

        internal string GetCategoryImgDirPath()
        {
            try
            {
                return _config["Path:CategoryImgDir"];
            }
            catch (Exception e)
            {
                throw e;
                //throw new Exception("Not found Path:CustomerImgDirPath in appsettings.json");
            }
        }

        internal string GetMaintenanceImgDirPath()
        {
            try
            {
                return _config["Path:MaintenanceImgDir"];
            }
            catch (Exception e)
            {
                throw e;
                //throw new Exception("Not found Path:CustomerImgDirPath in appsettings.json");
            }
        }

        internal void ConfigStaticMaintenanceImages(IApplicationBuilder app)
        {
            ConfigStaticImages(
                _config["Path:MaintenanceImgDir"],
                _config["Path:MaintenanceImgRequestPath"],
                app
            );
        }

        /**
         * Config image storing directory, image request path
         * if the directory path imgDirPath is not exists then create it 
         */
        private void ConfigStaticImages(
            string imgDirPath, 
            string requestPath,
            IApplicationBuilder app)
        {
            if (!Directory.Exists(imgDirPath))
            {
                Directory.CreateDirectory(imgDirPath);
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(imgDirPath),
                RequestPath = requestPath
            });
        }

        internal void ConfigStaticCategoryImages(IApplicationBuilder app)
        {
            ConfigStaticImages(
                _config["Path:CategoryImgDir"],
                _config["Path:CategoryImgRequestPath"],
                app
            );
        }
    }
}
