using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Writers;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.EF.Interceptor;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

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
            services.AddDbContext<EcommerceDBContext>(
                opt => opt.UseLazyLoadingProxies()
                    .UseSqlServer(connectionString)
                    .AddInterceptors(new SoftDeleteInterceptor())
            );

            services.AddHostedService<DBInitilizerService>();
        }

    }

    /// <summary>
    /// Db initilizer 
    /// Create database if not exist and run init sql 
    /// </summary>
    public sealed class DBInitilizerService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DBInitilizerService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<EcommerceDBContext>();
            dbContext.Database.EnsureCreated();
            if (Program.IsStartedWithMain)
            {
                RunInitSql(dbContext);
            }
        }


        private void RunInitSql(EcommerceDBContext context)
        {
            string initSql = File.ReadAllText("Server/init.sql");
            if (string.IsNullOrEmpty(initSql))
            {
                throw new Exception("Not found init sql file");
            }

            context.Database.ExecuteSqlRaw(initSql);
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

    }
}

