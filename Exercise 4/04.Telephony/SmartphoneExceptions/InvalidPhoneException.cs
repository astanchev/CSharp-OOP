namespace _04.Telephony.SmartphoneExceptions
{
    using System;

    public class InvalidPhoneException : Exception
    {
        private const string ExcMessage = "Invalid number!";

        public InvalidPhoneException()
            :base(ExcMessage)
        {
            
        }
    }
}