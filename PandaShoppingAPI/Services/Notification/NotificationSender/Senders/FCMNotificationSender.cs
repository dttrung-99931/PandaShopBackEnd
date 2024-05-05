using System;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public class FCMNotificationSender : INotificationSender
    {
        public bool Send(PushNotificationSend noti)
        {
            return true;
        }
    }
}

