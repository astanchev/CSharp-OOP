namespace LoggingLibrary.Common.Exceptions
{
    using System;

    public class InvalidAppenderTypeException : Exception
    {
        private const string ExcMessage = "Invalid Appender Type!";
        public InvalidAppenderTypeException()
            :base(ExcMessage)
        {
        }
    }
}