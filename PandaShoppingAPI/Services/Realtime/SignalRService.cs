using AutoMapper;
using Castle.Core.Internal;
using GarageSystem.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;
using PandaShoppingAPI.Utils.ServiceUtils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class SignalRService : IRealtimeService
    {
         private readonly IHubContext<SignalRNotificationHub> _hubContext;

        public SignalRService(IHubContext<SignalRNotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void Emit(int userId, string channelName, object data)
        {
            try
            {
                List<string> connectingSinalRIds = SignalRNotificationHub
                    .GetConnectingSignalRIdsOfUser(userId);

                connectingSinalRIds.ForEach(signalRId =>
                {
                    IClientProxy userHub = _hubContext.Clients.User(signalRId);

                    userHub.SendAsync(channelName, data);
                });
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
