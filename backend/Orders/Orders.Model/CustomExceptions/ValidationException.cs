using System;

namespace Orders.CustomExceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
