using System;
using PandaShoppingAPI.DataAccesses.EF;

namespace PandaShoppingAPI.Services
{
    public class FCMNotificationSender : INotificationSender
    {
        public bool Send(UserNotification noti)
        {
            return true;
        }
    }
}

