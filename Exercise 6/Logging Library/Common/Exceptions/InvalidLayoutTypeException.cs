namespace LoggingLibrary.Common.Exceptions
{
    using System;

    public class InvalidLayoutTypeException : Exception
    {
        private const string ExcMessage = "Invalid Layout Type!";
        public InvalidLayoutTypeException()
            :base(ExcMessage)
        {
        }
    }
}