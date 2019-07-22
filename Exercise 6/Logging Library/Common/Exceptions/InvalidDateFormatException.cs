namespace LoggingLibrary.Common.Exceptions
{
    using System;

    public class InvalidDateFormatException : Exception
    {
        private const string ExcMessage = "Invalid DateTime Format!";
        public InvalidDateFormatException()
            :base(ExcMessage)
        {
        }
    }
}