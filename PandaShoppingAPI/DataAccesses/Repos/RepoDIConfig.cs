using Microsoft.Extensions.DependencyInjection;
using PandaShoppingAPI.Services;
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
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<ICartRepo, CartRepo>();
            services.AddScoped<IShopRepo, ShopRepo>();
            services.AddScoped<IProductOptionRepo, ProductOptionRepo>();
            services.AddScoped<IProductPropertyValueRepo, ProductPropertyValueRepo>();
            services.AddScoped<IProductOptionValueRepo, ProductOptionValueRepo>();
            services.AddScoped<IProductImageRepo, ProductImageRepo>();
            services.AddScoped<ICartDetailRepo, CartDetailRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IAddressRepo, AddressRepo>();
            services.AddScoped<IWarehouseRepo, WarehouseRepo>();
            services.AddScoped<IWarehouseInputRepo, WarehouseInputRepo>();
            services.AddScoped<IWarehouseInputRepo, WarehouseInputRepo>();
            services.AddScoped<IWarehouseOutputDetailRepo, WarehouseOutputDetailRepo>();
            services.AddScoped<IProductBatchRepo, ProductBatchRepo>();
            services.AddScoped<IWarehouseInputService, WarehouseInputService>();
            services.AddScoped<IProductBatchInventoryRepo, ProductBatchInventoryRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IDeliveryRepo, DeliveryRepo>();
            services.AddScoped<IPaymentMethodRepo, PaymentMethodRepo>();
            services.AddScoped<IDeliveryMethodRepo, DeliveryMethodRepo>();
            services.AddScoped<IProductDeliveryMethodRepo, ProductDeliveryMethodRepo>();
        }
    }
}
