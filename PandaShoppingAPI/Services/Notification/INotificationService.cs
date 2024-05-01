using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Services
{
    public interface INotificationService : IBaseService<Notification, NotificationModel, NotificationFilter>
    {
        Notification CreateOrderStatusUpdatedNoti(int orderId);
        Notification CreateOrderCreatedNoti(int orderId);
        NotificationOverviewResponse GetNotificationOverview(NotificationFilter filter);
    }
}
