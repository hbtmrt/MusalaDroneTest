namespace MusalaDrones.Core.Statics
{
    public static class Constants
    {
        public const string InMemoryTableName = "MusalaDrones";

        // Assumption: The maximum number of the fleet is assumed to be 10.
        public const int DronesLimitInFleet = 10;

        // The percentage of the battery level in the drone to carry medical items.
        public const int AcceptableBatterLevel = 25;

        public static class ErrorMessage
        {
            public const string CannotRegisterMoreDrones = "Sorry, the fleet has reached the maximum amount of drones that can be loaded.";
            public const string MedicationItemsNotFound = "Medication items not found in DB for medication item ids: {0}.";
            public const string InvalidDroneModel = "Invalid drone model.";
            public const string InvalidDroneState = "Invalid drone state.";
        }
    }
}