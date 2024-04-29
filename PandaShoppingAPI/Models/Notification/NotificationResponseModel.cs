using AutoMapper;
using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class NotificationResponse : BaseModel<Notification, NotificationResponse>
    {
        public string title { get; set; }
        public string description { get; set; }
        public NotificationType type { get; set; }

        public virtual NotificationDataResponse data { get; set; }
    }
}
