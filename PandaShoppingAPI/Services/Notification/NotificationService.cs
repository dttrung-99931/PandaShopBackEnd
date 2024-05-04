using AutoMapper;
using PandaShoppingAPI.Configs.Messages;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class NotificationService : BaseService<INotificationRepo, Notification, NotificationModel, NotificationFilter>, 
        INotificationService
    {
        private readonly IUserNotificationRepo _userNotiRepo;
        private readonly INotificationReceiverRepo _notiReceiverRepo;
        private readonly IOrderRepo _orderRepo;
        private readonly INotificationSenderService _notiSenderService;

        public NotificationService(
            INotificationRepo repo,
            IUserNotificationRepo userNotiRepo,
            INotificationReceiverRepo notiReceiverRepo,
            IOrderRepo orderRepo,
            INotificationSenderService notiSenderService) : base(repo)
        {
            _userNotiRepo = userNotiRepo;
            _notiReceiverRepo = notiReceiverRepo;
            _orderRepo = orderRepo;
            _notiSenderService = notiSenderService;
        }

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

        public Notification CreateOrderStatusUpdatedNoti(int orderId)
        {
            return CreateOrderNoti(orderId, OrderMessages.titleStatusUpdated, NotificationType.UserOrderNoti);
        }

        public Notification CreateOrderCreatedNoti(int orderId)
        {
            return CreateOrderNoti(orderId, OrderMessages.titleCreated, NotificationType.ShopOrderNoti);
        }

        private Notification CreateOrderNoti(int orderId, string title, NotificationType type)
        {
            Order order = _orderRepo.GetById(orderId);
            int receivedUserId = type == NotificationType.ShopOrderNoti 
                // TDOO: Otmz get shop user id from order
                ? order.OrderDetail.First().productOption.product.shop.User_.First().id 
                : order.userId;
            Notification noti = new Notification
            {
                title = title,
                description = order.GetStatusMessage(),
                data = new DataAccesses.EF.NotificationData
                {
                    orderId = orderId,
                },
                type = type,
                UserNotification = new List<UserNotification>() {
                    new UserNotification
                    {
                        notificationReceiverId = _notiSenderService
                            .DetermineSuitableReceiver(receivedUserId).id,
                        status = UserNotificationStatus.Sent,
                    }
                },
            };
            _repo.Insert(noti);
            _notiSenderService.Send(noti.id);
            return noti;
        }

        public void UpdateNotificationStatusToSeen(List<int> notificaitonIds)
        {
            _userNotiRepo.UpdateIf(
                userNoti => 
                    notificaitonIds.Contains(userNoti.notificationId) && 
                    userNoti.status == UserNotificationStatus.Sent, 
                (userNoti) => userNoti.status = UserNotificationStatus.Seen
            );
                
        }
    }
}
