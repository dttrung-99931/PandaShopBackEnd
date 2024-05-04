using System;
using System.Collections.Generic;
using System.Linq;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
	public interface INotificationSender
    {
        public abstract bool Send(NotificationSend noti);
	}

    public class NotificationSenderFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public NotificationSenderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public bool Send(NotificationSend noti)
        {
            INotificationSender sender;
            switch (noti.receiver.senderType)
            {
                case NotificationSenderType.SignalR:
                    sender = (INotificationSender) _serviceProvider.GetService(typeof(SignalRNotificationSender));
                    break;
                case NotificationSenderType.FCM:
                    sender = (INotificationSender)_serviceProvider.GetService(typeof(FCMNotificationSender));
                    break;
                default:
                    throw new Exception($"Invalid noti sender type {noti.receiver}");
            }
            sender.Send(noti);
            return true;
        }
    }
}

