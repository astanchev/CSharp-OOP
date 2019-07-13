namespace _04.Telephony.Models
{
    using System;
    using Interfaces;
    using Vallidators;
    using SmartphoneExceptions;

    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string phoneNumber)
        {
            if (Vallidator.ValidatePhoneNumber(phoneNumber))
            {
                return $"Calling... {phoneNumber}";
            }
            else
            {
                throw new InvalidPhoneException();
            }
        }

        public string Browse(string url)
        {
            if (Vallidator.ValidateURL(url))
            {
                return $"Browsing: {url}!";
            }
            else
            {
                throw new InvalidURLException();
            }
        }
    }
}