using System;

namespace FunnyCalculator
{
    public class IllegalFormatException : Exception
    {
        public IllegalFormatException(string message)
            : base(message)
        {
        }

        public IllegalFormatException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
