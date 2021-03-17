using System;

namespace FunnyCalculator
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(string message)
            : base(message)
        {
        }

        public NegativesNotAllowedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
