using System;
using System.Collections.Generic;
using System.Text;

namespace MusalaDrones.Core.Exceptions
{
    /// <summary>
    /// This is used when the battery goes into low level.
    /// </summary>
    public class LowBatteryLevelException : Exception
    {
        public LowBatteryLevelException()
        {
        }

        public LowBatteryLevelException(string message)
            : base(message)
        {
        }

        public LowBatteryLevelException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
