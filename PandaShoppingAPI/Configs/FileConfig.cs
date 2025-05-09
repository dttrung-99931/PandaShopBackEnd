﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Utils
{
    public class FileConfig
    {
        private readonly IConfiguration _config;

        public FileConfig(IConfiguration config)
        {
            _config = config;
        }


        static public void ConfigFileMaxSize(IServiceCollection services)
        {
            long _500MB = 1024 * 1024 * 500; // 500 MB
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = _500MB; 
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = _500MB; 
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = _500MB; 
            });
        }
        
        internal void ConfigFiles(IApplicationBuilder app)
        {
            ConfigStaticPanMusic(app);
            ConfigStaticVideos(app);
            ConfigStatisVideoThumbImage(app);
            ConfigStaticCategoryImages(app);
            ConfigStaticProductImages(app);
        }

        internal string GetPanVideoDirPath()
        {
            return _config["Path:PanVideoDir"];
        }

        internal string GetPanVideoThumbImageDirPath()
        {
            return _config["Path:PanVideoThumbImageDir"];
        }

        internal string GetPanMusicDirPath()
        {
            return _config["Path:PanMusicDir"];
        }


        internal string GetCategoryImgDirPath()
        {
            return _config["Path:CategoryImgDir"];
        }

        internal string GetProductImgDirPath()
        {
            return _config["Path:ProductImgDir"];
        }

        internal void ConfigStaticCategoryImages(IApplicationBuilder app)
        {
            ConfigStaticFiles(
                Path.Combine(Directory.GetCurrentDirectory(), _config["Path:CategoryImgDir"]),
                _config["Path:CategoryImgRequestPath"],
                app
            );
        }

        internal void ConfigStaticProductImages(IApplicationBuilder app)
        {
            ConfigStaticFiles(
                Path.Combine(Directory.GetCurrentDirectory(), _config["Path:ProductImgDir"]),
                _config["Path:ProductImgRequestPath"],
                app
            );
        }

        internal void ConfigStaticVideos(IApplicationBuilder app)
        {
            ConfigStaticFiles(
                Path.Combine(Directory.GetCurrentDirectory(), _config["Path:PanVideoDir"]),
                _config["Path:PanVideoRequestPath"],
                app,
                contentTypeProvider: new FileExtensionContentTypeProvider
                {
                    Mappings = 
                    {
                        [".mpd"] = "application/dash+xml",
                        [".m3u8"] = "application/x-mpegURL",
                        [".ts"] = "video/mp2t",
                    }
                },
                serveUnknownFileTypes: true,
                defaultContentType: "application/octet-stream"  
            );
        }

        internal void ConfigStatisVideoThumbImage(IApplicationBuilder app)
        {
            ConfigStaticFiles(
                Path.Combine(Directory.GetCurrentDirectory(), _config["Path:PanVideoThumbImageDir"]),
                _config["Path:PanVideoThumbImageRequestPath"],
                app
            );
        }

        internal void ConfigStaticPanMusic(IApplicationBuilder app)
        {
            ConfigStaticFiles(
                Path.Combine(Directory.GetCurrentDirectory(), _config["Path:PanMusicDir"]),
                _config["Path:PanMusicRequestPath"],
                app
            );
        }

         /**
         * Config file storing directory, file request path
         * if the directory path is not exists then create it 
         */
        private void ConfigStaticFiles(
            string dirPath, 
            string requestPath,
            IApplicationBuilder app,
            IContentTypeProvider contentTypeProvider = null,
            bool serveUnknownFileTypes = false,
            string defaultContentType = null
        )
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(dirPath),
                RequestPath = requestPath,
                ContentTypeProvider = contentTypeProvider,
                ServeUnknownFileTypes = serveUnknownFileTypes,
                DefaultContentType = defaultContentType,
            });
        }

        internal string GetDirPath(FileType fileType)
        {
            switch (fileType)
            {
                case FileType.CategoryImage:
                    return GetCategoryImgDirPath();
                case FileType.ProductImage:
                    return GetProductImgDirPath();
                case FileType.PanVideo:
                    return GetPanVideoDirPath();
                case FileType.PanVideoThumbImage:
                    return GetPanVideoThumbImageDirPath();
                case FileType.PanMusic:
                    return GetPanMusicDirPath();
                default:
                    throw new Exception("File type not supported");
            }
        }

        internal string GetRequestPath(FileType fileType)
        {
            switch (fileType)
            {
                case FileType.CategoryImage:
                    return _config["Path:CategoryImgRequestPath"];
                case FileType.ProductImage:
                    return _config["Path:ProductImgRequestPath"];
                case FileType.PanVideo:
                    return _config["Path:PanVideoRequestPath"];
                case FileType.PanVideoThumbImage:
                    return _config["Path:PanVideoThumbImageRequestPath"];
                case FileType.PanMusic:
                    return _config["Path:PanMusicRequestPath"];
                default:
                    throw new Exception("File type not supported");
            }
        }
    }
}
