namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionCorrection = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption + FuelConsumptionCorrection, tankCapacity)
        {
        }

        public override double FuelRefuelCorrection { get => 0.95; }

    }
}