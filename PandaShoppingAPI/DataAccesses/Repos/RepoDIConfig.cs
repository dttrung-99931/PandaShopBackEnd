﻿using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<IWarehouseOutputRepo, WarehouseOutputRepo>();
            services.AddScoped<IWarehouseOutputDetailRepo, WarehouseOutputDetailRepo>();
            services.AddScoped<IProductBatchRepo, ProductBatchRepo>();
            services.AddScoped<IWarehouseInputService, WarehouseInputService>();
            services.AddScoped<IProductBatchInventoryRepo, ProductBatchInventoryRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IDeliveryRepo, DeliveryRepo>();
            services.AddScoped<IPaymentMethodRepo, PaymentMethodRepo>();
            services.AddScoped<IDeliveryMethodRepo, DeliveryMethodRepo>();
            services.AddScoped<IProductDeliveryMethodRepo, ProductDeliveryMethodRepo>();
            services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
            services.AddScoped<IInvoiceRepo, InvoiceRepo>();
            services.AddScoped<INotificationRepo, NotificationRepo>();
            services.AddScoped<INotificationDataRepo, NotificationDataRepo>();
            services.AddScoped<INotificationReceiverRepo, NotificationReceiverRepo>();
            services.AddScoped<IUserNotificationRepo, UserNotificationRepo>();
            services.AddScoped<IUserRoleRepo, UserRoleRepo>();
            services.AddScoped<IDriverRepo, DriverRepo>();
            services.AddScoped<IDeliveryDriverRepo, DeliveryDriverRepo>();
            services.AddScoped<IDeliveryPartnerUnitRepo, DeliveryPartnerUnitRepo>();
            services.AddScoped<IDeliveryLocationRepo, DeliveryLocationRepo>();
            services.AddScoped<IDeliveryDriverTrackingRepo, DeliveryDriverTrackingRepo>();
            services.AddScoped<IOrderDeliveryRepo, OrderDeliveryRepo>();
            services.AddScoped<IPanVideoRepo, PanVideoRepo>();

            // Store file at local service. In the future, we can use cloud storage
            // by implementing IFileRepo interface and replacing LocalFileRepo
            services.AddScoped<IFileRepo, LocalFileRepo>();

            services.AddScoped<IPanMusicRepo, PanMusicRepo>();

        }
    }
}
