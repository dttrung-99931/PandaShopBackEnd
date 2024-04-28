using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class NotificationReceiver : BaseEntity
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string fcmToken { get; set; }
        public string signalRToken { get; set; }
        public NotificationSenderType senderType { get; set; }

        public virtual User_ user { get; set; }
        public virtual ICollection<UserNotification> UserNotification { get; set; }
    }

}