
using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class NotificationData : BaseEntity
    {
        public int id { get; set; }
        public int notificationId { get; set; }
        public int? orderId { get; set; }

        public virtual Order order { get; set; }
        public virtual Notification notification { get; set; }
    }

}
