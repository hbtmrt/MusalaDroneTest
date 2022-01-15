using Microsoft.EntityFrameworkCore;
using MusalaDrones.Core.Exceptions;
using MusalaDrones.Core.Models;
using MusalaDrones.Core.Statics;
using MusalaDrones.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaDrones.Business.Services
{
    /// <summary>
    /// Concreate implementation of drone operating service.
    /// </summary>
    public sealed class DroneOperatorService : IDroneOperatorService
    {
        #region Declarations

        private readonly DroneContext dbContext;

        #endregion Declarations

        #region Constructors

        public DroneOperatorService(DroneContext context)
        {
            dbContext = context;
        }

        #endregion Constructors

        #region Methods - IDroneOperatorService Members

        public async Task<Drone> RegisterDroneAsync(Drone drone)
        {
            if (dbContext.Drones.Count() >= Constants.DronesLimitInFleet)
            {
                throw new DronesReachedMaxNumberInFleetException(Constants.ErrorMessage.CannotRegisterMoreDrones);
            }

            if (dbContext.Drones.Any(d => d.SerialNumber.Equals(drone.SerialNumber)))
            {
                throw new NotUniqueExeption(Constants.ErrorMessage.NotAUniqueSerial);
            }

            drone.State = Core.Statics.Enums.DroneState.IDLE; // A drone is always Idle when registering (assuming)

            dbContext.Drones.Add(drone);
            await dbContext.SaveChangesAsync();

            return drone;
        }

        public async Task<Drone> LoadDroneAsync(int id, List<int> medicationItemIds)
        {
            Drone drone = await dbContext.Drones
                .Include(d => d.MedicationItems)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (drone == null)
            {
                throw new DroneNotFoundException();
            }

            if (drone.BatteryCapacity < Constants.AcceptableBatterLevel)
            {
                throw new LowBatteryLevelException();
            }

            // Moment before the medical items are loading, the drone is set to loading state.
            drone.State = Core.Statics.Enums.DroneState.LOADING;
            await dbContext.SaveChangesAsync();

            var medicationItems = dbContext.MedicationItems.Where(mi => medicationItemIds.Contains(mi.Id)).ToList();

            if (medicationItems.Count != medicationItemIds.Count)
            {
                var notFoundMedicationItemIds = medicationItemIds.Except(medicationItems.Select(mi => mi.Id)).ToList();

                drone.State = Core.Statics.Enums.DroneState.IDLE; // rolling back to IDLE state.
                await dbContext.SaveChangesAsync();

                throw new MedicationItemNotFoundException(
                    string.Format(Constants.ErrorMessage.MedicationItemsNotFound, string.Join(",", notFoundMedicationItemIds)));
            }

            decimal totalWeight = dbContext.MedicationItems
                .Where(mi => medicationItemIds.Contains(mi.Id))
                .Sum(mi => mi.Weight);

            if (totalWeight > drone.WeightLimit)
            {
                drone.State = Core.Statics.Enums.DroneState.IDLE; // rolling back to IDLE state.
                await dbContext.SaveChangesAsync();
                throw new DroneOverloadException();
            }

            if (drone.MedicationItems == null)
            {
                drone.MedicationItems = medicationItems;
            }
            else
            {
                medicationItems.ForEach(mi =>
                {
                    drone.MedicationItems.Add(mi);
                });
            }

            drone.State = Core.Statics.Enums.DroneState.LOADED; // everything has been loaded successfully.
            await dbContext.SaveChangesAsync();

            return drone;
        }

        public async Task<List<MedicationItem>> GetLoadedMedicationItemsAsync(int id)
        {
            Drone drone = await dbContext.Drones
                .Include(d => d.MedicationItems)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (drone == null)
            {
                throw new DroneNotFoundException();
            }

            return drone.MedicationItems?.ToList();
        }

        public async Task<List<Drone>> GetAvailableDronesAsync()
        {
            return await dbContext.Drones
                .Include(d => d.MedicationItems)
                .Where(d => d.State == Core.Statics.Enums.DroneState.IDLE
                    && d.BatteryCapacity > Constants.AcceptableBatterLevel).ToListAsync();
        }

        public async Task<decimal> GetBatteryLevelAsync(int id)
        {
            Drone drone = await dbContext.Drones.FindAsync(id);

            if (drone == null)
            {
                throw new DroneNotFoundException();
            }

            return drone.BatteryCapacity;
        }

        #endregion Methods - IDroneOperatorService Members
    }
}