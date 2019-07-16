namespace MilitaryElite.Exceptions
{
    using System;

    public class InvalidStateExceprion : Exception
    {
        private const string ExcMessage = "Invalid State input!";
        public InvalidStateExceprion() 
            : base(ExcMessage)
        {
        }
    }
}