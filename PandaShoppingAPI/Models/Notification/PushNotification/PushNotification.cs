
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.Models
{
    public class PushNotification : BaseModel<Notification, PushNotification>
    {
        public string title { get; set; }
        public string description { get; set; }
        public NotificationType type { get; set; }
        public DateTime createdDate { get; set; } = DateTime.UtcNow;
        public PushNotificationData data { get; set; }

        public string ToJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
        public Dictionary<string, object> ToDictionary()
        {
            string json = JsonConvert.SerializeObject(this);
            Dictionary<string, object> dict =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(Uri.UnescapeDataString(json));
            return dict;
        }
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

