using System;

namespace MusalaDrones.Core.Exceptions
{
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