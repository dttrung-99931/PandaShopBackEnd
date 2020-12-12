using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PandaShoppingAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSystem.Config
{
    public class AuthConfig
    {
        internal static void Config(IServiceCollection services, IConfiguration config)
        {
            services.AddCors(
                options => {
                    options.AddPolicy(
                        Constants.POLICY_CORS_ALL,
                        builder => builder
                        //.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed(host => true) // SignalR need it
                        //.WithOrigins("*")
                        .AllowCredentials()
                        .Build());
                    }
            );

            services.AddCors(
                options => {
                    options.AddPolicy(
                        Constants.POLICY_UPLOAD_FILE,
                        builder => builder
                        .AllowAnyOrigin()
                        .WithMethods("POST")
                        .AllowAnyHeader());
                    }
            );

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = config["Jwt:Issuer"],
                        ValidAudience = config["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(config["Jwt:Key"]))
                    };

                    // Add an additional authentication option for SignalR clients
                    // which authenticate via querystrimg 'access_token'
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];

                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) &&
                                (path.StartsWithSegments("/realtime")))
                            {
                                // Read the token out of the query string
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };

                });
        }
    }
}
