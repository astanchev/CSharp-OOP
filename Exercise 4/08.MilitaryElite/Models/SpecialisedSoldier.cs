namespace MilitaryElite.Models
{
    using Contracts;
    using Enumerations;
    using Exceptions;
    using System;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            this.ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private void ParseCorps(string corpsAsString)
        {
            Corps corps;

            bool isParsed = Enum.TryParse<Corps>(corpsAsString, out corps);

            if (!isParsed)
            {
                throw new InvalidCorpseException();
            }

            this.Corps = corps;
        }

        public override string ToString()
        {
            return base.ToString() 
                     + Environment.NewLine
                     + $"Corps: {this.Corps}";
        }
    }
}