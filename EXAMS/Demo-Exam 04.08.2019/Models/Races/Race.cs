namespace MXGP.Models.Races
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Riders.Contracts;
    using Utilities.Messages;

    public class Race : IRace
    {
        private const int MinNameLenght = 5;
        private const int MinLaps = 1;

        private string name;
        private int laps;
        private List<IRider> riders;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.riders = new List<IRider>();
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

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < MinLaps)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidNumberOfLaps, MinLaps));
                }

                this.laps = value;
            }
        }
        public IReadOnlyCollection<IRider> Riders => this.riders.AsReadOnly();
        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException(nameof(rider), ExceptionMessages.RiderInvalid);
            }

            if (!rider.CanParticipate)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RiderNotParticipate, rider.Name));
            }

            if (this.riders.Any(r => r.Name == rider.Name))
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name,
                    this.Name));
            }

            this.riders.Add(rider);
        }
    }
}
