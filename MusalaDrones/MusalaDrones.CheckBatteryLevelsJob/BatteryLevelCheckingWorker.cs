using Microsoft.Extensions.Hosting;
using MusalaDrones.CheckBatteryLevelsJob.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace MusalaDrones.CheckBatteryLevelsJob
{
    public class BatteryLevelCheckingWorker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await new BatterLevelCheckingHelper().CheckBatteryLevelsAsync(stoppingToken);
        }
    }
}