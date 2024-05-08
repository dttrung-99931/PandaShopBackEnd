using System;
using System.Collections.Generic;
using PandaShoppingAPI.DataAccesses.EF;

namespace PandaShoppingAPI.Services
{
	public interface INotificationSenderService
	{
        public bool Send(Notification noti);
        public bool Send(int notiId);
        List<NotificationReceiver> DetermineSuitableReceivers(IEnumerable<NotificationReceiver> receivers);
        List<NotificationReceiver> DetermineSuitableReceiver(int userId);
    }
}

