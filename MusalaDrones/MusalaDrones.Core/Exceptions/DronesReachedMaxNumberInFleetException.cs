using System;

namespace MusalaDrones.Core.Exceptions
{
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