namespace MilitaryElite.Exceptions
{
    using System;
    public class InvalidCorpseException : Exception
    {
        private const string ExcMessage = "Invalid Corps name!";
        public InvalidCorpseException() 
            : base(ExcMessage)
        {
        }
    }

}