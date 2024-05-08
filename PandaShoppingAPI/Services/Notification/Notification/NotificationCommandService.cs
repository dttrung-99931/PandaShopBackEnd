using AutoMapper;
using Castle.Core.Internal;
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
    public partial class NotificationService 
    {
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

            return CreateNoti(
                type,
                title,
                order.GetStatusMessage(),
                new NotificationData
                {
                    orderId = orderId,
                },
                receivedUserId
            );
        }

        private Notification CreateNoti(
            NotificationType type, 
            string title, 
            string description, 
            NotificationData data,
            int receivedUserId
        )
        {
            List<NotificationReceiver> receivers = _notiSenderService
                .DetermineSuitableReceiver(receivedUserId);

            if (receivers.IsNullOrEmpty()){
                return null;
            }
            
            List<UserNotification> userNotis = receivers
                .Select(receiver => new UserNotification
                    {
                        notificationReceiverId = receiver.id,
                        status = UserNotificationStatus.Sent, // TODO: fixed
                    })
                .ToList();
            Notification noti = new Notification
            {
                title = title,
                description = description,
                data = data,
                type = type,
                UserNotification = userNotis,
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

        public void CreateNotificationReceiver(NotificationReceiverModel model)
        {
            bool exists = _notiReceiverRepo.Any(receiver => 
                receiver.userId == User.UserId && 
                receiver.senderType == model.senderType && 
                receiver.token == model.token);
            
            if (!exists) {
                _notiReceiverRepo.Insert(
                    new NotificationReceiver {
                        token  = model.token,
                        senderType = model.senderType,        
                        userId = User.UserId,
                    }
                );
            }
        }

    }
}
