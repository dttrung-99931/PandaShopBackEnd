using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;

namespace PandaShoppingAPI.Models
{
    public class PushNotificationSend 
    {
        public PushNotification data;
        public NotificationReceiverModel receiver;
    }

    public class NotificationReceiverModel : BaseModel<NotificationReceiver, NotificationReceiverModel>
    {
        public int userId { get; set; }
        public string fcmToken { get; set; }
        public string signalRToken { get; set; }
        public NotificationSenderType senderType { get; set; }
    }
    

}

