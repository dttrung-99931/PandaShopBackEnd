using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace PandaShoppingAPI.Configs 
{
    class HangfireConfig 
    {
        public static void Config(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {

            services.AddHangfire(
                (config) => config
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseSqlServerStorage(configuration["ConnectionString"])
            );

            services.AddHangfireServer();
        }
    }
}
