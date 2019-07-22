namespace LoggingLibrary.Errors.Factories
{
    using System;
    using System.Globalization;

    using Common;
    using Common.Exceptions;
    using Common.Enumerations;

    using Entities;
    using Contracts;


    public class ErrorFactory
    {
        public IError GetError(string dateString, string levelStr, string message)
        {
            Level level = MessageParameters.ParseLevel(levelStr);

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateString, MessageParameters.dateFormat, CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new InvalidDateFormatException();
            }

            return new Error(dateTime, message, level);
        }
    }
}