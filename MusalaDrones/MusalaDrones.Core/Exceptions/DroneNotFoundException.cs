using System;

namespace MusalaDrones.Core.Exceptions
{
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