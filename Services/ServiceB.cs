using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
using Serilog;

namespace SampleApp.Services
{
    public class ServiceB : BackgroundService
    {
        public ServiceB() //ILoggerFactory loggerFactory)
        {
            //Logger = loggerFactory.CreateLogger<ServiceB>();
        }

        //public ILogger Logger { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Log.Information("ServiceB is starting.");

            stoppingToken.Register(() => Log.Information("ServiceB is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                Log.Information("ServiceB is doing background work.");

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            Log.Information("ServiceB has stopped.");
        }
    }
}
