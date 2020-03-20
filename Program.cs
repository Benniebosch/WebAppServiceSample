using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleApp.Services;
using Serilog;

namespace SampleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builtConfig = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            //.AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builtConfig)
                //.MinimumLevel.Debug()
                //.WriteTo.Console()
                //.WriteTo.File(builtConfig["Logging:FilePath"])
                .CreateLogger();


            try
            {
                Log.Information("Host CreateDefaultBuilder");

                return Host.CreateDefaultBuilder(args)
                      .UseWindowsService()
                      .ConfigureServices((hostContext, services) =>
                      {
                          services.AddHostedService<ServiceA>();
                          services.AddHostedService<ServiceB>();
                      })
                      .ConfigureWebHostDefaults(webBuilder =>
                      {
                          webBuilder.UseStartup<Startup>();
                      });
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host builder error");

                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }
    }
}
