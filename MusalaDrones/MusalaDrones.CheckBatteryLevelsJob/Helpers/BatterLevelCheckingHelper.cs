using Microsoft.EntityFrameworkCore;
using MusalaDrones.Core.Models;
using MusalaDrones.Core.Statics;
using MusalaDrones.Data.DbContexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusalaDrones.CheckBatteryLevelsJob.Helpers
{
    public class BatterLevelCheckingHelper
    {
        private readonly DroneContext dbContext;

        public BatterLevelCheckingHelper()
        {
            dbContext = GetDroneContext();
        }

        internal async Task CheckBatteryLevelsAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var allDrones = dbContext.Drones.ToList();
                allDrones.ForEach(d =>
                {
                    dbContext.History.Add(new BatteryLevelHistory
                    {
                        DroneId = d.Id,
                        BatteryLevel = d.BatteryCapacity,
                        CheckedOn = DateTime.Now
                    });
                });

                await dbContext.SaveChangesAsync();

                await Task.Delay(Constants.BatterLevelCheckingJobInterval, stoppingToken);
            }
        }

        private DroneContext GetDroneContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DroneContext>().UseInMemoryDatabase(Constants.InMemoryTableName);
            return new DroneContext(optionsBuilder.Options);
        }
    }
}