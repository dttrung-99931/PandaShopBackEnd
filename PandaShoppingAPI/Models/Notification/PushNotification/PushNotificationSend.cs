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
        public string token { get; set; }
        public int userId { get; set; }
        public NotificationSenderType senderType { get; set; }
    }
    

}

