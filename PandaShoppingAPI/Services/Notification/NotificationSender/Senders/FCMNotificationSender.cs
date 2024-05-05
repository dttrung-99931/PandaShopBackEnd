using System;
using FirebaseAdmin.Messaging;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public class FCMNotificationSender : INotificationSender
    {
        public bool Send(PushNotificationSend noti)
        {
            Message fcmNoti = new Message 
            {
                Data = noti.data.ToDictionary(),
                Token = noti.receiver.token,
            };
            FirebaseMessaging.DefaultInstance.SendAsync(fcmNoti);
            return true;
        }
    }
}

