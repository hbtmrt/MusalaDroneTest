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
        Task RegisterDroneAsync(Drone drone);

        /// <summary>
        /// Loads medication items to the drone specified by the id.
        /// </summary>
        /// <param name="medicationItems"></param>
        Task LoadDroneAsync(int id, List<MedicationItem> medicationItems);

        /// <summary>
        /// Returns a list of medication items of type <see cref="MedicationItem" for the drone specified by the id./>
        /// </summary>
        /// <param name="id">The ID of drone.</param>
        /// <returns>The list of medication items of type <see cref="MedicationItem".</returns>
        Task GetLoadedMedicationItemsAsync(int id);

        /// <summary>
        /// Returns available drones in the fleet.
        /// The drones which are in Idle mode and battery leve having more than 25%.
        /// </summary>
        /// <returns>A list of objects of type <see cref="Drone"/>.</returns>
        Task<List<Drone>> GetAvailableDrones();
    }
}