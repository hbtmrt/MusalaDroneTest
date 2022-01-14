using System;

namespace MusalaDrones.Core.Exceptions
{
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