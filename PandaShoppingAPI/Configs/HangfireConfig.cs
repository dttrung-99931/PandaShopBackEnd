using System;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Hangfire.Dashboard.BasicAuthorization;
using Microsoft.Extensions.Configuration;

namespace PandaShoppingAPI.Configs
{
    public static class HangfireConfig
    {
        public static void Config(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {

            services.AddHangfire(
                (config) => config
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseSqlServerStorage
                    (
                        configuration["ConnectionString"],
                        new Hangfire.SqlServer.SqlServerStorageOptions
                        {
                            CommandTimeout = TimeSpan.FromMinutes(30) // Set job timeout to 30 minutes
                        }
                    )
            );

            services.AddHangfireServer();
        }


        public static IApplicationBuilder UsePandaHangfireDashboard(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseHangfireDashboard(
               "/hangfire",
               new DashboardOptions
               {
                   Authorization = new[]
                   {
                        new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                        {
                            RequireSsl = false,
                            Users = new []
                            {
                                new BasicAuthAuthorizationUser
                                {
                                    Login = configuration["Hangfire:DashboardLogin:Username"],
                                    PasswordClear =  configuration["Hangfire:DashboardLogin:Password"]
                                }
                            }

                        })
                   }
               }
           );
            return app;
        }
    }
}
