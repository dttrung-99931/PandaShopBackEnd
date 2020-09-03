﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class RepoDIConfig
    {
        static public void Config(IServiceCollection services)
        {
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IImageRepo, ImageRepo>();
            services.AddScoped<ITemplateRepo, TemplateRepo>();
            services.AddScoped<IPropertyRepo, PropertyRepo>();
            services.AddScoped<IPropertyTemplateRepo, PropertyTemplateRepo>();
            services.AddScoped<IPropertyTemplateValueRepo, PropertyTemplateValueRepo>();
        }
    }
}
