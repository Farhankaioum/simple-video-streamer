using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetflixClone.Foundation.Contexts;
using NetflixClone.Web.DataAccess;
using Serilog;
using Serilog.Events;
using System;
using System.Threading.Tasks;

namespace NetflixClone.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Database.RunMigrations();

            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
               .AddEnvironmentVariables()
               .Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(configBuilder)
                .CreateLogger();

            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    // automatically apply pending migration when project run
                    var applicationDbContext = services.GetRequiredService<ApplicationDbContext>();
                    await applicationDbContext.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, ex.Message);
                }
            }

            try
            {
                Log.Information("Application Starting up");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
                host.Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
