
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.Models
{
    public class PushNotification : JsonBaseModel<Notification, PushNotification>
    {
        public string title { get; set; }
        public string description { get; set; }
        public NotificationType type { get; set; }
        public DateTime createdDate { get; set; } = DateTime.UtcNow;
        public PushNotificationData data { get; set; }

    }

    public class PushNotificationData : BaseModel<NotificationData, NotificationDataModel>
    {
        public PushNotificationOrderData order { get; set; }
    }

    public class PushNotificationOrderData : BaseModel<Order, PushNotificationOrderData>
    {
        [JsonProperty("orderDetails")]
        public List<ShortOrderDetailResponse> OrderDetail { get; set; }
    }

}

