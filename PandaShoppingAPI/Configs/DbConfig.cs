using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PandaShoppingAPI.DataAccesses.EF;
using System;

namespace PandaShoppingAPI.Configs
{
    public class DbConfig
    {
        internal static void Config(IServiceCollection services, IConfiguration config)
        {
            string connectionString = config["ConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Not found connection string in appSetting file. Check Dev / prod appSetting");
            }

            // TODO: fix lazy load
            services.AddDbContext<EcommerceDBContext>(opt => opt.UseLazyLoadingProxies().UseSqlServer(connectionString));

        }
    }
}
