using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartDetailService, CartDetailService>();
            services.AddScoped<IAdsService, AdsService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IWarehouseInputService, WarehouseInputService>();
            services.AddScoped<IProductBatchService, ProductBatchService>();
            services.AddScoped<IProductInventoryService, ProductInventoryService>();
        }
    }
}
