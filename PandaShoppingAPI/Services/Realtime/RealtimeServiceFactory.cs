using AutoMapper;
using Castle.Core.Internal;
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
    public enum RealtimeType { SignalR }
    public class RealtimeServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private IRealtimeService _signalRService;

        public RealtimeServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void EmitEvent(int userId, string channelName, RealtimeEvent realtimeEvent)
        {
            Emit(userId, channelName, realtimeEvent.ToJson(), RealtimeType.SignalR);
        }

        public void Emit(int userId, string channelName, object data, RealtimeType type = RealtimeType.SignalR)
        {
            IRealtimeService service;
            switch (type)
            {
                case RealtimeType.SignalR:
                    service = _signalRService ?? (IRealtimeService) _serviceProvider.GetService(typeof(SignalRService));
                    break;
                default:
                    throw new Exception($"Invalid Realtime type {type}");
            }
            service.Emit(userId, channelName, data);
        }
    }
}
