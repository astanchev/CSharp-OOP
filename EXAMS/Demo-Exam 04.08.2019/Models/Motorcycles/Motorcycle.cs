namespace MXGP.Models.Motorcycles
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Motorcycle : IMotorcycle
    {
        private const int MinModelLenght = 4;
        private string model;
        private int horsePower;
        
        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }
        
        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value) || value.Length < MinModelLenght)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel, value, MinModelLenght));
                }

                this.model = value;
            }
        }

        //Has to be implemented in child classes;
        public abstract int HorsePower { get; protected set; }

        public double CubicCentimeters
        {
            get ;
            private set ;
        }
        public double CalculateRacePoints(int laps)
        {
            return (this.CubicCentimeters / this.HorsePower) * laps;
        }
    }
}