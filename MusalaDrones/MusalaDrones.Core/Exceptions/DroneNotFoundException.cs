using System;

namespace MusalaDrones.Core.Exceptions
{
    /// <summary>
    /// This is used when the drone cannot be found in the DB.
    /// </summary>
    public class DroneNotFoundException : Exception
    {
        public DroneNotFoundException()
        {
        }

        public DroneNotFoundException(string message)
            : base(message)
        {
        }

        public DroneNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}