namespace Vehicles.Factories
{
    using Models;

    public static class TruckFactory
    {
        public static Truck CreateTruck(string[] truckInfo)
        {
            return new Truck(
                double.Parse(truckInfo[1]), 
                double.Parse(truckInfo[2]), 
                int.Parse(truckInfo[3]));
        }
    }
}