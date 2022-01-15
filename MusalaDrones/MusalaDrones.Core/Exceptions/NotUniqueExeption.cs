using System;

namespace MusalaDrones.Core.Exceptions
{
    public class NotUniqueExeption : Exception
    {
        public NotUniqueExeption()
        {
        }

        public NotUniqueExeption(string message)
            : base(message)
        {
        }

        public NotUniqueExeption(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}