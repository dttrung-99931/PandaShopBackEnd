using System;
using PandaShoppingAPI.DataAccesses.EF;

namespace PandaShoppingAPI.Services
{
    public class SignalRNotificationSender : INotificationSender
    {
        public bool Send(UserNotification noti)
        {
            return true;
        }
    }
}

