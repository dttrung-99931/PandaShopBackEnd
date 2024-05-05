using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public class NotificationSenderService : INotificationSenderService
    {
        private readonly NotificationSenderFactory _senderFactory;
        private readonly INotificationRepo _notiRepo;
        private readonly INotificationReceiverRepo _notiReceiverRepo;

        public NotificationSenderService(NotificationSenderFactory senderFactory, INotificationRepo notiRepo, INotificationReceiverRepo receiverRepo)
        {
            _senderFactory = senderFactory;
            _notiRepo = notiRepo;
            _notiReceiverRepo = receiverRepo;
        }

        public NotificationReceiver DetermineSuitableReceiver(IEnumerable<NotificationReceiver> receivers)
        {
            // TODO: determine noti receiver by prefred SingalR fist then FCM, ...
            return receivers.First();
        }

        public NotificationReceiver DetermineSuitableReceiver(int userId)
        {
            return DetermineSuitableReceiver(_notiReceiverRepo.Where(receiver => receiver.userId == userId));
        }

        public bool Send(Notification noti)
        {
            PushNotification notiData = Mapper.Map<PushNotification>(noti);
            foreach (UserNotification userNoti in noti.UserNotification)
            {
                PushNotificationSend notiSend = new PushNotificationSend 
                {
                    data =  notiData,
                    receiver = Mapper.Map<NotificationReceiverModel>(userNoti.receiver),

                };
                if (!_senderFactory.Send(notiSend))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Send(int notiId)
        {
            Notification noti = _notiRepo.GetById(notiId);
            return Send(noti);
        }
    }
}

