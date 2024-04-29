using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Configs.Middlewares
{
	public class NotificationMiddelware
	{
        private readonly RequestDelegate _next;

        public NotificationMiddelware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, INotificationService notiService)
        {
            await _next(context);
            try
            {
                string path = context.Request.Path;
                if (APIPaths.Orders.isOrderProcessingPath(path, out int orderId) && orderId != Constants.EMPTY_ID)
                {
                    notiService.CreateOrderStatusUpdatedNoti(orderId);
                }

            }
            catch (Exception)
            {
                // TODO log
            }

        }
    }

    public static class NotificationMiddelwareExtensions
    {
        public static IApplicationBuilder UseNotificationMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NotificationMiddelware>();
        }
    }
}

