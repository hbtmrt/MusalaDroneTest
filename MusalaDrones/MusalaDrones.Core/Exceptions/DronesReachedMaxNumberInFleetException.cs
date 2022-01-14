using System;

namespace MusalaDrones.Core.Exceptions
{
    /// <summary>
    /// This is used when the fleet has reached the maximum number of drones that it can handle and a new drone is going to be registered.
    /// </summary>
    public class DronesReachedMaxNumberInFleetException : Exception
    {
        public DronesReachedMaxNumberInFleetException()
        {
        }

        public DronesReachedMaxNumberInFleetException(string message)
            : base(message)
        {
        }

        public DronesReachedMaxNumberInFleetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}