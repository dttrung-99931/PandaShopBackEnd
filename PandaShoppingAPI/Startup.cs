using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GarageSystem.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PandaShoppingAPI.Configs;
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

            services.AddSingleton<ConfigUtil>();

            services.AddControllers()
                // Make [DataContract] working in asp.net core
                .AddNewtonsoftJson();
            
            services.AddSwaggerGen(
                action =>
                {
                    action.SwaggerDoc
                    (
                        "v1",
                        new OpenApiInfo
                        {
                            Version = "v1",
                            Title = "Panda Shop Api documents"
                        }
                    );

                    // Add Authentication 
                    action.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });

                    action.AddSecurityRequirement(
                        new OpenApiSecurityRequirement(){
                        {
                          new OpenApiSecurityScheme
                          {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,
                            },
                            new List<string>()
                          }
                        }
                    );
                }
            );

            services.AddHttpContextAccessor();

            //services.AddAuthentication().AddOAuth();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IWebHostEnvironment env, ConfigUtil configUtil)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(
                action => action.SwaggerEndpoint("v1/swagger.json", "Panda shop api"));

            app.UseHttpsRedirection();

            app.UseRouting();

            // This must be put above app.UseAuthorization();
            // Otherwise 401 always returned 
            app.UseAuthentication();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Config image storing folder, base request image url 
            configUtil.ConfigStaticCategoryImages(app);
            configUtil.ConfigStaticProductImages(app);

            // Config file access for App_Data folder
            string baseDir = env.ContentRootPath;
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(baseDir, "App_Data"));
        }
    }
}
