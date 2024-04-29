using PandaShoppingAPI.Configs.Messages;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
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
            
            if (filter.onlyForShop.HasValue)
            {
                userNotis = userNotis.Where(userNoti => userNoti.receiver.userId != User.UserId == filter.onlyForShop.Value);
            }

            IQueryable<Notification> notis = userNotis.Select(userNoti => userNoti.notification);

            return notis;
        }

        public Notification CreateOrderStatusUpdatedNoti(int orderId)
        {
            Order order = _orderRepo.GetById(orderId);
            Notification noti = new Notification
            {
                title = OrderMessages.titleStatusUpdated,
                description = order.GetStatusMessage(),
                data = new NotificationData
                {
                    orderId = orderId,
                },
                type = NotificationType.Order,
                UserNotification = new List<UserNotification>() {
                    new UserNotification
                    {
                        notificationReceiverId = _notiSenderService.DetermineSuitableReceiver(order.user.Receivers).id,
                    }
                }
            };
            _repo.Insert(noti);
            _notiSenderService.Send(noti.id);
            return noti;
        }
    }
}
