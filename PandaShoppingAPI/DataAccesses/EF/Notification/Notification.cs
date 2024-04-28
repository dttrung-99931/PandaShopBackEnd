using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Notification: BaseEntity
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public NotificationType type { get; set; }

        public virtual NotificationData data { get; set; }
        public virtual ICollection<UserNotification> UserNotification { get; set; }
    }

}
