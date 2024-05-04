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
        public const string onNotification = "onNotification";
        private readonly IHubContext<SignalRNotificationHub> _hubContext;

        public SignalRNotificationSender(IHubContext<SignalRNotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public bool Send(NotificationSend noti)
        {
            try
            {
                List<string> connectingSinalRIds = SignalRNotificationHub
                    .GetConnectingSignalRIdsOfUser(noti.receiver.userId);

                connectingSinalRIds.ForEach(signalRId =>
                {
                    IClientProxy userHub = _hubContext.Clients.User(signalRId);

                    userHub.SendAsync(onNotification, noti.data.ToJson());
                });
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
    }
}

