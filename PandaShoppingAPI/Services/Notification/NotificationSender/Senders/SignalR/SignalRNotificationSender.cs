using System;
using System.Collections.Generic;
using GarageSystem.Services;
using Microsoft.AspNetCore.SignalR;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public class SignalRNotificationSender : INotificationSender
    {
        private readonly RealtimeServiceFactory _realtime;

        public SignalRNotificationSender(RealtimeServiceFactory realtime)
        {
            _realtime = realtime;
        }

        public bool Send(PushNotificationSend noti)
        {
            try
            {
                _realtime.Emit
                (
                    noti.receiver.userId, 
                    RelatimeChannels.onNotification, 
                    noti.data.ToJson(), 
                    RealtimeType.SignalR
                );
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
    }
}

