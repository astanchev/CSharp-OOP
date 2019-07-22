namespace LoggingLibrary.Common
{
    using System;
    using System.Globalization;

    using Enumerations;
    using Errors.Contracts;
    using Exceptions;
    using Layouts.Contracts;

    public static class MessageParameters
    {
        public const string dateFormat = "M/dd/yyyy h:mm:ss tt";

        public static string GetFormattedMessage(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string time = dateTime.ToString(MessageParameters.dateFormat, CultureInfo.InvariantCulture);

            string formattedMessage = String.Format(format, time, level.ToString(), message);

            return formattedMessage;
        }

        public static Level ParseLevel(string levelStr)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelStr, out level);

            if (!hasParsed)
            {
                throw new InvalidLevelTypeException();
            }

            return level;
        }
    }
}