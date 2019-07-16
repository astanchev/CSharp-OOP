namespace Vehicles.Factories
{
    using Models;

    public static class CarFactory
    {
        public static Car CreateCar(string[] carInfo)
        {
            return new Car(
                double.Parse(carInfo[1]), 
                double.Parse(carInfo[2]), 
                int.Parse(carInfo[3]));
        }
    }
}