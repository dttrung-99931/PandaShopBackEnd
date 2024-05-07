using System;
using System.Collections.Generic;
using System.Data.Common;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Data.SqlClient.Server;
using Microsoft.Extensions.Options;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public class FCMNotificationSender : INotificationSender
    {
        public bool Send(PushNotificationSend noti)
        {
            Message fcmNoti = new Message 
            {
                Data = new Dictionary<string, string>
                {
                    // To send [noti.data] so we need to convert to json string.
                    // Data is Dictionary<string, string> that can not hold the noti.data (nested filed is not string)
                    { "data", noti.data.ToJson() }
                },
                Token = noti.receiver.token,
            };
            FirebaseMessaging.DefaultInstance.SendAsync(fcmNoti);
            return true;
        }
    }
}

