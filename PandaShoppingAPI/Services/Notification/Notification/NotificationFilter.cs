using System;
using PandaShoppingAPI.DataAccesses.EF;

namespace PandaShoppingAPI.Services
{
    public class NotificationFilter : Filter
    {
        public UserNotificationStatus? status { get; set; }
        public bool? onlyForShop { get; set; }
    }
}