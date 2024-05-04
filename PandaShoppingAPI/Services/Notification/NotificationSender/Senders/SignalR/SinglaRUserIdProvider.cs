using Microsoft.AspNetCore.SignalR;
using PandaShoppingAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GarageSystem.Services
{
    public class SignalRUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            string userId = connection.User?.FindFirst(Constants.CLAIM_USER_ID)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                connection.Abort();
                return null;
            }
            
            string singalRId = $"{userId}_{DateTime.Now.Millisecond}";
            return singalRId;
        }

        public static int GetUserId(string signalRId)
        {
            return int.Parse(signalRId.Split('_').First());
        }
    }
}
