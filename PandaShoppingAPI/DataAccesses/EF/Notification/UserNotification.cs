using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class UserNotification : BaseEntity
    {
        public int id { get; set; }
        public int notificationId { get; set; }
        public int notificationReceiverId { get; set; }
        public UserNotificationStatus status { get; set; }
        public DateTime? seenDate { get; set; }

        public virtual Notification notification { get; set; }
        public virtual NotificationReceiver receiver { get; set; }
    }

}