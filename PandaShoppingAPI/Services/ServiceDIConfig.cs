using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IDeliveryMethodService, DeliveryMethodService>();

            // Notification
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<INotificationSenderService, NotificationSenderService>();
            services.AddScoped<FCMNotificationSender>();
            services.AddScoped<SignalRNotificationSender>();
            services.AddScoped<NotificationSenderFactory>();

            // Driver
            services.AddScoped<IDriverService, DriverService>();

            // Realtime
            services.AddScoped<SignalRService>();
            services.AddScoped<RealtimeServiceFactory>();

            // PanVideo
            services.AddScoped<IPanVideoService, PanVideoService>();
            services.AddScoped<HlsPanvideoEncoder>();
            services.AddScoped<DashPanvideoEncoder>();
            services.AddScoped<PanvideoEncoderFactory>();
            services.AddScoped<ThumbnailVideoService>();
        }
    }
}
