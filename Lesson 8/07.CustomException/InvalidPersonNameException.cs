namespace _07.CustomException
{
    using System;

    public class InvalidPersonNameException : Exception
    {
        private const string ExcMessage = "The name cannot contains special character or numeric value!";
        public InvalidPersonNameException()
            : base(ExcMessage)
        {
        }

        public InvalidPersonNameException(string message) : base(message)
        {
        }

        public InvalidPersonNameException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}