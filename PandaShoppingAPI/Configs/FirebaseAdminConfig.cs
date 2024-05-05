using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using GarageSystem.Services;
using Google.Apis.Auth.OAuth2;
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
    public class FirebaseAdminConfig
    {
        internal static void Config(IServiceCollection services, IConfiguration config)
        {
            string firebaseProjectId = config["FirebaseProjectId"];
            FirebaseApp.Create(new AppOptions()
            {
                // TODO: Get file path from EVN
                Credential = GoogleCredential.FromFile("Server/firebase-key.json"),
            });
        }
    }
}
