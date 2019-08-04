namespace MXGP.Models.Riders
{
    using System;
    using Contracts;
    using Motorcycles.Contracts;
    using Utilities.Messages;

    public class Rider : IRider
    {
        private const int MinNameLenght = 5;

        private string name;
        public Rider(string name)
        {
            this.Name = name;
            this.CanParticipate = false;
            this.NumberOfWins = 0;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < MinNameLenght)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value, MinNameLenght));
                }

                this.name = value;
            }
        }
        public IMotorcycle Motorcycle { get; private set; }
        public int NumberOfWins { get; private set; }
        public bool CanParticipate { get; private set; }
        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(nameof(motorcycle), ExceptionMessages.MotorcycleInvalid);
            }

            this.Motorcycle = motorcycle;
            this.CanParticipate = true;
        }
    }
}
