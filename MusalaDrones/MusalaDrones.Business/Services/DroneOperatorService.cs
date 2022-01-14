﻿using Microsoft.EntityFrameworkCore;
using MusalaDrones.Core.Exceptions;
using MusalaDrones.Core.Models;
using MusalaDrones.Core.Statics;
using MusalaDrones.Data.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaDrones.Business.Services
{
    public sealed class DroneOperatorService : IDroneOperatorService
    {
        private readonly DroneContext dbContext;

        public DroneOperatorService(DroneContext context)
        {
            dbContext = context;
        }

        public async Task<List<Drone>> GetAvailableDrones()
        {
            return await dbContext.Drones
                .Where(d => d.State == Core.Statics.Enums.DroneState.IDLE
                    && d.BatteryCapacity > Constants.AcceptableBatterLevel).ToListAsync();
        }

        public async Task<decimal> GetBatteryLevel(int id)
        {
            Drone drone = await dbContext.Drones.FindAsync(id);

            if (drone == null)
            {
                throw new DroneNotFoundException();
            }

            return drone.BatteryCapacity;
        }

        public async Task<List<MedicationItem>> GetLoadedMedicationItemsAsync(int id)
        {
            Drone drone = await dbContext.Drones.FindAsync(id);

            if (drone == null)
            {
                throw new DroneNotFoundException();
            }

            return drone.MedicationItems.ToList();
        }

        public async Task LoadDroneAsync(int id, List<MedicationItem> medicationItems)
        {
            Drone drone = await dbContext.Drones.FindAsync(id);

            if (drone == null)
            {
                throw new DroneNotFoundException();
            }

            if (medicationItems.Sum(mi => mi.Weight) > drone.WeightLimit)
            {
                throw new DroneOverloadException();
            }

            drone.MedicationItems = medicationItems;
            await dbContext.SaveChangesAsync();
        }

        public async Task RegisterDroneAsync(Drone drone)
        {
            if (dbContext.Drones.Count() >= Constants.DronesLimitInFleet)
            {
                throw new DronesReachedMaxNumberInFleetException(Constants.ErrorMessage.CannotRegisterMoreDrones);
            }

            dbContext.Drones.Add(drone);
            await dbContext.SaveChangesAsync();
        }
    }
}