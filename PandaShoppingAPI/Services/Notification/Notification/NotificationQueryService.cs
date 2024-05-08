using AutoMapper;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using System.Collections.Generic;
using System.Linq;

namespace PandaShoppingAPI.Services
{
    public partial class NotificationService
    {
        public List<NotificationResponse> Get(NotificationFilter filter, out Meta meta)
        {
            var notis = FilterUserNotifications(filter)
                .Select(userNoti => new {
                    userNoti.notification,
                    userNoti.status,
                })
                .OrderByDescending(userNoti => userNoti.notification.createdDate)
                .ToList();
            
            List<NotificationResponse> responses = notis.Select(noti =>
            {
                NotificationResponse res = Mapper.Map<NotificationResponse>(noti.notification);
                res.status = noti.status;
                return res;
            }
            ).ToList(); 

            meta = Meta.ProcessAndCreate(notis.Count(), filter);

            return responses;
        }

        public override IQueryable<Notification> Fill(NotificationFilter filter)
        {
            IQueryable<Notification> notis = FilterUserNotifications(filter)
                .Select(userNoti => userNoti.notification)
                .OrderByDescending(noti => noti.createdDate);
            return notis;
        }

        public NotificationOverviewResponse GetNotificationOverview(NotificationFilter filter)
        {
            IQueryable<UserNotification> userNotis = FilterUserNotifications(filter);
            int newNotiNum = userNotis
                .Where(userNoti => userNoti.status != UserNotificationStatus.Seen)
                .Count();
            int total = userNotis.Count();
            return new NotificationOverviewResponse {
                newNotiNum = newNotiNum,
                total = total
            };
        }

        private IQueryable<UserNotification> FilterUserNotifications(NotificationFilter filter)
        {
            List<NotificationReceiver> notiReceivers = _notiReceiverRepo.GetAllOfUser(User.UserId);
            List<int> notiReceiverIds = notiReceivers.Select(receiver => receiver.id).ToList();
            IQueryable<UserNotification> userNotis = _userNotiRepo
                .Where(userNoti => notiReceiverIds.Contains(userNoti.notificationReceiverId));

            if (filter.status.HasValue)
            {
                userNotis = userNotis.Where(userNoti => userNoti.status == filter.status.Value);
            }

            if (filter.onlyForShop.HasValue)
            {
                List<NotificationType> filterTypes =
                filter.onlyForShop.Value
                    ? new List<NotificationType>{
                            NotificationType.ShopOrderNoti
                        }
                    :
                    new List<NotificationType>{
                        NotificationType.UserOrderNoti
                    };
                // TODO: used Noti type to determine wheather noti for shop insted of order status 
                userNotis = userNotis.Where(userNoti => filterTypes.Contains(userNoti.notification.type));
            }

            return userNotis;
        }

    }
}
