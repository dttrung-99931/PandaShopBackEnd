using Microsoft.Extensions.DependencyInjection;
using PandaShoppingAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class ServiceDIConfig
    {
        static public void Config(IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
