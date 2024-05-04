using GarageSystem.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.EF.Interceptor;
using System;
using System.IO;

namespace PandaShoppingAPI.Configs
{
    public class SignalRConfig
    {
        internal static void Config(IServiceCollection services)
        {
            services.AddSignalR().AddJsonProtocol();
            services.AddSingleton<IUserIdProvider, SignalRUserIdProvider>();
        }
    }
}
