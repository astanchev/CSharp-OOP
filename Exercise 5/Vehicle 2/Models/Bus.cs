namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double FuelConsumptionCorrection = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption + FuelConsumptionCorrection, tankCapacity)
        {
        }


        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= 1.4;
            return base.Drive(distance);
        }
    }
}