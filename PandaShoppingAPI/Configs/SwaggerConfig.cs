using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace PandaShoppingAPI.Configs
{
    public class SwaggerConfig
    {
        internal static void Config(IServiceCollection services)
        {
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

        }
    }
}
