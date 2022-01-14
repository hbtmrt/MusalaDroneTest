using System;

namespace MusalaDrones.Core.Exceptions
{
    /// <summary>
    /// This is used when the drone is going to be overloaded with new medical items.
    /// </summary>
    public class DroneOverloadException : Exception
    {
        public DroneOverloadException()
        {
        }

        public DroneOverloadException(string message)
            : base(message)
        {
        }

        public DroneOverloadException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}