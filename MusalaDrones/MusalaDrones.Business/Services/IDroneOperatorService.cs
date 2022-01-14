using MusalaDrones.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusalaDrones.Business.Services
{
    public interface IDroneOperatorService
    {
        /// <summary>
        /// Registers a drone to the fleet.
        /// </summary>
        /// <param name="drone"></param>
        /// <exception cref="DronesReachedMaxNumberInFleetException">The maximum number of drones in the fleet has reached.</exception>
        Task RegisterDroneAsync(Drone drone);

        /// <summary>
        /// Loads medication items to the drone specified by the id.
        /// </summary>
        /// <param name="medicationItemIds">List of Medicaiton item ids.</param>
        Task LoadDroneAsync(int id, List<int> medicationItemIds);

        /// <summary>
        /// Returns a list of medication items of type <see cref="MedicationItem" for the drone specified by the id./>
        /// </summary>
        /// <param name="id">The ID of drone.</param>
        /// <returns>The list of medication items of type <see cref="MedicationItem".</returns>
        Task<List<MedicationItem>> GetLoadedMedicationItemsAsync(int id);

        /// <summary>
        /// Returns available drones in the fleet.
        /// The drones which are in Idle mode and battery leve having more than 25%.
        /// </summary>
        /// <returns>A list of objects of type <see cref="Drone"/>.</returns>
        Task<List<Drone>> GetAvailableDrones();

        /// <summary>
        /// Returns the battery level of the drone specified by the id.
        /// </summary>
        /// <param name="id">The Id of the drone.</param>
        /// <returns>The battery level.</returns>
        Task<decimal> GetBatteryLevel(int id);
    }
}