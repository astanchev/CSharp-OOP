namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity {get ; protected set;}

        public double FuelConsumption {get ; protected set;}

        public virtual double FuelConsumptionCorrection
        {
            get => 0.0;
        }

        public virtual double FuelRefuelCorrection
        {
            get => 1.0;
        }

        public string Drive(double distance)
        {
            if (IsFuelEnough(distance))
            {
                double neededFuel = distance * (this.FuelConsumption + this.FuelConsumptionCorrection);
                this.FuelQuantity -= neededFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double amount)
        {
            this.FuelQuantity += this.FuelRefuelCorrection*amount;
        }

        private bool IsFuelEnough (double distance)
        {
            double neededFuel = distance * (this.FuelConsumption + this.FuelConsumptionCorrection);
            return this.FuelQuantity >= neededFuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}