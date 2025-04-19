using System;
using System.IO;
using GarageSystem.Config;
using GarageSystem.Services;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PandaShoppingAPI.Configs;
using PandaShoppingAPI.Configs.Middlewares;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            MapperConfig.Config(Configuration);

            ServiceDIConfig.Config(services);
            
            RepoDIConfig.Config(services);

            AuthConfig.Config(services, Configuration);

            DbConfig.Config(services, Configuration);

            services.AddSingleton<FileConfig>();

            services.AddControllers()
                // Make [DataContract] working in asp.net core
                .AddNewtonsoftJson();

            SwaggerConfig.Config(services);
            
            SignalRConfig.Config(services);

            FirebaseAdminConfig.Config(services, Configuration);

            FileConfig.ConfigFileMaxSize(services);

            HangfireConfig.Config(services, Configuration);

            services.AddHttpContextAccessor();
            //services.AddAuthentication().AddOAuth();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IWebHostEnvironment env, FileConfig configUtil)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(
                action => action.SwaggerEndpoint("v1/swagger.json", "Panda shop api"));

            app.UseHttpsRedirection();

            app.UseNotificationMiddleware();

            app.UseRouting();

            // This must be put above app.UseAuthorization();
            // Otherwise 401 always returned 
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseHangfireDashboard();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRNotificationHub>
                (
                    APIPaths.singalR, 
                    options =>
                    {
                        options.Transports =
                            HttpTransportType.WebSockets |
                            HttpTransportType.LongPolling;
                    }
                );
            });

            // Config image storing folder, base request image url 
            configUtil.ConfigFiles(app);
            

            // Config file access for App_Data folder
            string baseDir = env.ContentRootPath;
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(baseDir, "App_Data"));
        }
    }
}
