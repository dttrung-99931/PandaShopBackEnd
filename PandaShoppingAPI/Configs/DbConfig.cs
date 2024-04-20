using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.IO;

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

            EcommerceDBContext context = services.BuildServiceProvider().GetService<EcommerceDBContext>();

            string initSql = File.ReadAllText("Server/init.sql");
            if (string.IsNullOrEmpty(initSql))
            {
                throw new Exception("Not found init sql file");
            }

            context.Database.ExecuteSqlRaw(initSql);
        }
    }
}
