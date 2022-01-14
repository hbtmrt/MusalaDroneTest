using MusalaDrones.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusalaDrones.Business.Services
{
    public sealed class DroneOperatorService : IDroneOperatorService
    {
        public Task<List<Drone>> GetAvailableDrones()
        {
            throw new NotImplementedException();
        }

        public Task GetLoadedMedicationItemsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task LoadDroneAsync(int id, List<MedicationItem> medicationItems)
        {
            throw new NotImplementedException();
        }

        public Task RegisterDroneAsync(Drone drone)
        {
            throw new NotImplementedException();
        }
    }
}
