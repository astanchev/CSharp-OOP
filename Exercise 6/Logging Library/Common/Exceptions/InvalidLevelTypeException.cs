namespace LoggingLibrary.Common.Exceptions
{
    using System;

    public class InvalidLevelTypeException : Exception
    {
        private const string ExcMessage = "Invalid Level Type!";
        public InvalidLevelTypeException()
            :base(ExcMessage)
        {
        }
    }
}