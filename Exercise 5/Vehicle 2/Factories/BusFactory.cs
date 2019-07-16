namespace Vehicles.Factories
{
    using Models;

    public static class BusFactory
    {
        public static Bus CreateBus(string[] busInfo)
        {
            return new Bus(
                double.Parse(busInfo[1]), 
                double.Parse(busInfo[2]), 
                int.Parse(busInfo[3]));
        }
    }
}