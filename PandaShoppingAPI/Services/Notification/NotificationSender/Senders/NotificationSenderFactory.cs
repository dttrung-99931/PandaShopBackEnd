using System;
using System.Collections.Generic;
using System.Linq;
using PandaShoppingAPI.DataAccesses.EF;

namespace PandaShoppingAPI.Services
{
	public interface INotificationSender
    {
        public abstract bool Send(UserNotification noti);
	}

    public class NotificationSenderFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public NotificationSenderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public bool Send(UserNotification userNoti)
        {
            INotificationSender sender;
            switch (userNoti.receiver.senderType)
            {
                case NotificationSenderType.SignalR:
                    sender = (INotificationSender) _serviceProvider.GetService(typeof(SignalRNotificationSender));
                    break;
                case NotificationSenderType.FCM:
                    sender = (INotificationSender)_serviceProvider.GetService(typeof(FCMNotificationSender));
                    break;
                default:
                    throw new Exception($"Invalid noti sender type {userNoti.receiver.senderType}");
            }
            sender.Send(userNoti);
            return true;
        }
    }
}

