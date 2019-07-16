namespace MilitaryElite.Exceptions
{
    using System;

    public class InvalidMissonComplition : Exception
    {
        private const string ExcMessage = "Mission is already finished!";
        public InvalidMissonComplition() 
            : base(ExcMessage)
        {
        }
    }
}