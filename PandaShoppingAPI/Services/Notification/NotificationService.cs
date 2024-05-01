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

        public override IQueryable<Notification> Fill(NotificationFilter filter)
        {
            List<NotificationReceiver> notiReceivers = _notiReceiverRepo.GetAllOfUser(User.UserId);
            List<int> notiReceiverIds = notiReceivers.Select(receiver => receiver.id).ToList();
            IQueryable<UserNotification> userNotis =  _userNotiRepo
                .Where(userNoti => notiReceiverIds.Contains(userNoti.notificationReceiverId));

            if (filter.status.HasValue)
            {
                userNotis = userNotis.Where(userNoti => userNoti.status == filter.status.Value);
            }
            
            if (filter.onlyForShop.HasValue )
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

            IQueryable<Notification> notis = userNotis
                .Select(userNoti => userNoti.notification)
                .OrderByDescending(noti => noti.createdDate);

            return notis;
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
            Notification noti = new Notification
            {
                title = title,
                description = order.GetStatusMessage(),
                data = new NotificationData
                {
                    orderId = orderId,
                },
                type = type,
                UserNotification = new List<UserNotification>() {
                    new UserNotification
                    {
                        notificationReceiverId = _notiSenderService.DetermineSuitableReceiver(order.userId).id,
                    }
                }
            };
            _repo.Insert(noti);
            _notiSenderService.Send(noti.id);
            return noti;
        }
    }
}
