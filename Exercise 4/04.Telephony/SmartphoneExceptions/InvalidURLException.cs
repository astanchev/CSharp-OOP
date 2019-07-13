namespace _04.Telephony.SmartphoneExceptions
{
    using System;

    public class InvalidURLException : Exception
    {
        private const string ExcMessage = "Invalid URL!";

        public InvalidURLException()
            : base(ExcMessage)
        {
        }
    }
}