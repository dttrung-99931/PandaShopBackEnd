using System.Collections.Generic;
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
        List<NotificationResponse> Get(NotificationFilter filter, out Meta meta);
        void UpdateNotificationStatusToSeen(List<int> notificaitonIds);
        void CreateNotificationReceiver(NotificationReceiverModel model);
        public Notification CreateDriverTakeDeliveryNoti(int shopUserId, int deliveryId, string driverLicencePlate);
    }
}
