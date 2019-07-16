namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumptionCorrection { get => 1.6; }

        public override double FuelRefuelCorrection { get => 0.95; }

    }
}