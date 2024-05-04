using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GarageSystem.Services
{

    [Authorize]
    public class SignalRNotificationHub: Hub
    {
        public static HashSet<string> ConnectingSignalRIds = new HashSet<string>();
 
        public SignalRNotificationHub()
        {
        }

        public override Task OnConnectedAsync()
        {
            string signalRId = Context.UserIdentifier;
            ConnectingSignalRIds.Add(signalRId);
            OnSingalConnected(signalRId);
            return base.OnConnectedAsync();
        }

        private void OnSingalConnected(string signalRId)
        {
            Debug.WriteLine(signalRId + " connected");
            // int userId = SignalRUserIdProvider.GetUserId(signalRId);
            // string token = GetQueryParam(Constatns.QUERY_PARAM_ACCESS_TOKEN);
        }

        private string GetQueryParam(string queryParam)
        {
            return Context.GetHttpContext().Request.Query[queryParam];
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var signalRId = Context.UserIdentifier;
            ConnectingSignalRIds.Remove(signalRId);
            OnSignalRDisconnected(signalRId);
            return base.OnDisconnectedAsync(exception);
        }

        public void OnSignalRDisconnected(string signalRID)
        {
            Debug.WriteLine(signalRID + " disconnected");
        }

        internal static bool IsUserConnecting(string userId)
        {
            return ConnectingSignalRIds.Contains(userId);
        }

        internal static List<string> GetConnectingSignalRIdsOfUser(int userId)
        {
            return ConnectingSignalRIds
                .Where(signalRID => SignalRUserIdProvider.GetUserId(signalRID) == userId)
                .ToList();
        }
    }
}
