using System;
using System.Collections.Generic;
using PandaShoppingAPI.DataAccesses.EF;

namespace PandaShoppingAPI.Services
{
	public interface INotificationSenderService
	{
        public bool Send(Notification noti);
        public bool Send(int notiId);
        NotificationReceiver DetermineSuitableReceiver(IEnumerable<NotificationReceiver> receivers);
        NotificationReceiver DetermineSuitableReceiver(int userId);
    }
}

