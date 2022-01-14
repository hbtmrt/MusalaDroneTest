using System;

namespace MusalaDrones.Core.Exceptions
{
    /// <summary>
    /// This is used when the medication item is not found.
    /// </summary>
    public class MedicationItemNotFoundException : Exception
    {
        public MedicationItemNotFoundException()
        {
        }

        public MedicationItemNotFoundException(string message)
            : base(message)
        {
        }

        public MedicationItemNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}