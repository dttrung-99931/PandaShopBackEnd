using System;
using System.Collections.Generic;
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
                    return;
                }

                if (path == APIPaths.Orders.endpoint && context.Request.Method == "POST")
                {
                    List<int> orderIds = HeaderUtils.GetCreatedIdsFromHeader(context.Response.Headers);
                    foreach (int id in orderIds){
                        notiService.CreateOrderCreatedNoti(id);
                    }
                }
            }
            catch (Exception)
            {
                // TODO show exceptiuin while debugging
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

