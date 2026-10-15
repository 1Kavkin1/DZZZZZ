using System;

namespace DZ.Exceptions
{
    // Власне виключення для некоректних параметрів фігури
    public class InvalidShapeException : Exception
    {
        public string ParamName { get; }

        public InvalidShapeException()
        {
        }

        public InvalidShapeException(string message) : base(message)
        {
        }

        public InvalidShapeException(string message, string paramName) : base(message)
        {
            ParamName = paramName;
        }
    }
}
