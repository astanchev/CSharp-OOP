namespace MilitaryElite.Models
{
    using Contracts;
    using Enumerations;
    using Exceptions;
    using System;

    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.ParseState(state);
        }
        public string CodeName { get; private set;}
        public State State { get; private set;}
        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidMissonComplition();
            }

            this.State = State.Finished;
        }

        public void ParseState(string stateAsString)
        {
            State state;

            bool isParsed = Enum.TryParse<State>(stateAsString, out state);

            if (!isParsed)
            {
                throw new InvalidStateExceprion();
            }

            this.State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}