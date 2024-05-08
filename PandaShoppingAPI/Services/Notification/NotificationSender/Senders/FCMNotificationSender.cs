using System;
using System.Collections.Generic;
using System.Data.Common;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Data.SqlClient.Server;
using Microsoft.Extensions.Options;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public class FCMNotificationSender : INotificationSender
    {
        private readonly INotificationReceiverRepo _notiReceiverRepo;

        public FCMNotificationSender(INotificationReceiverRepo notiReceiverRepo)
        {
            _notiReceiverRepo = notiReceiverRepo;
        }

        public bool Send(PushNotificationSend noti)
        {
            Message fcmNoti = CreateMessage(noti);
            try
            {
                FirebaseMessaging.DefaultInstance.SendAsync(fcmNoti);
            }
            catch (FirebaseMessagingException fcmException)
            {
                // TODO: Hanlde remove expired token
                // if (fcmException.ErrorCode == FirebaseAdmin.ErrorCode.UN)
                return false;
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        private static Message CreateMessage(PushNotificationSend noti)
        {
            return new Message
            {
                Data = new Dictionary<string, string>
                {
                    // To send [noti.data] so we need to convert to json string.
                    // Data is Dictionary<string, string> that can not hold the noti.data (nested filed is not string)
                    { "data", noti.data.ToJson() }
                },
                Token = noti.receiver.token,
            };
        }
    }
}

