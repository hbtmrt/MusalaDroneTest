using MusalaDrones.Core.Models;
using MusalaDrones.Core.Statics.Enums;
using MusalaDrones.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusalaDrones.Data.Seeders
{
    public static class DroneSeeder
    {
        #region Image base 64

        private static readonly string imageBase64 = "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";

        #endregion Image base 64

        private static int medicationItemCounter = 1;
        private static int droneCounter = 1;
        private static Random random = new Random();

        public static void Seed(DroneContext context)
        {
            AddDrones(context);
            context.SaveChanges();
        }

        private static void AddDrones(DroneContext context)
        {
            AddDrone(context, DroneState.IDLE);
            AddDrone(context, DroneState.IDLE);
            AddDrone(context, DroneState.LOADING);
            AddDrone(context, DroneState.LOADED);
            AddDrone(context, DroneState.DELIVERING);
            AddDrone(context, DroneState.DELIVERED);
            AddDrone(context, DroneState.RETURNING);
            AddDrone(context, DroneState.LOADING);
        }

        private static void AddDrone(DroneContext context, DroneState state)
        {
            Drone drone = new Drone
            {
                Id = droneCounter,
                BatteryCapacity = random.Next(1, 100),
                Model = GetRandomDroneModel(),
                SerialNumber = Guid.NewGuid().ToString(),
                State = state,
                WeightLimit = random.Next(400, 500)
            };

            AddMedicationItems(drone);
            context.Drones.Add(drone);

            droneCounter++;
        }

        private static void AddMedicationItems(Drone drone)
        {
            int maxItemsAmount = random.Next(1, 5);
            drone.MedicationItems = new List<MedicationItem>();

            int retries = 0;

            while (retries < 10 && drone.MedicationItems.Count < maxItemsAmount && drone.WeightLimit >= drone.MedicationItems.Sum(mi => mi.Weight))
            {
                retries++;

                int itemWeight = random.Next(100, 500);

                if (drone.WeightLimit < drone.MedicationItems.Sum(mi => mi.Weight) + itemWeight)
                {
                    continue;
                }

                drone.MedicationItems.Add(new MedicationItem
                {
                    Id = medicationItemCounter,
                    Weight = itemWeight,
                    Code = $"MC_CODE_{medicationItemCounter}",
                    Name = $"MC-Name_{medicationItemCounter}",
                    Image = GetImageBytes()
                });

                medicationItemCounter++;
            }
        }

        private static byte[] GetImageBytes()
        {
            return Convert.FromBase64String(imageBase64);
        }

        private static DroneModel GetRandomDroneModel()
        {
            var v = Enum.GetValues(typeof(DroneModel));
            return (DroneModel)v.GetValue(random.Next(v.Length));
        }
    }
}