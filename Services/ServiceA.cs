using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
////using Microsoft.Extensions.Logging;
using Serilog;

namespace SampleApp.Services
{
    public class ServiceA : BackgroundService
    {
        public ServiceA()//ILoggerFactory loggerFactory)
        {
            //Logger = loggerFactory.CreateLogger<ServiceA>();
        }

        //public ILogger Logger { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Log.Information("ServiceA is starting.");

            stoppingToken.Register(() => Log.Information("ServiceA is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                Log.Information("ServiceA is doing background work.");

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            Log.Information("ServiceA has stopped.");
        }
    }
}
