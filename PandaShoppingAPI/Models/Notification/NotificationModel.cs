using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class NotificationModel: BaseModel<Notification, NotificationModel>
    {
        public string title { get; set; }
        public string description { get; set; }
        public NotificationType type { get; set; }
        public NotificationDataModel data { get; set; }
    }
}
