
using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class NotificationSend 
    {
        public NotificationSendData data;
        public NotificationReceiverModel receiver;
    }

    public class NotificationReceiverModel : BaseModel<NotificationReceiver, NotificationReceiverModel>
    {
        public int userId { get; set; }
        public string fcmToken { get; set; }
        public string signalRToken { get; set; }
        public NotificationSenderType senderType { get; set; }
    }
    
    public class NotificationSendData : BaseModel<Notification, NotificationSendData>
    {
        public string title { get; set; }
        public string description { get; set; }
        public NotificationType type { get; set; }
        public DateTime createdDate { get; set; } = DateTime.UtcNow;
        public NotificationData data { get; set; }

        public string ToJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
    }

    public class NotificationData : BaseModel<DataAccesses.EF.NotificationData, NotificationDataModel>
    {
        public int? orderId { get; set; }
    }
}

