using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Business.BackgroundIssues
{
    public class PeriodicBackgroundTask : BackgroundService
    {
        private readonly TimeSpan period = TimeSpan.FromMinutes(1);
        private readonly ILogger<PeriodicBackgroundTask> logger;
        public PeriodicBackgroundTask(ILogger<PeriodicBackgroundTask> logger)
        {
            this.logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer periodicTimer = new(period);
            while (!stoppingToken.IsCancellationRequested && await periodicTimer.WaitForNextTickAsync(stoppingToken))
            {
                logger.LogInformation($"executed {nameof(PeriodicBackgroundTask)}");
            }
        }
    }
}
