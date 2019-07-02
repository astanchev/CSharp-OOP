namespace P01_RawData
{
    public class CarFactory
    {
        public Car Create(
            string model, 
            Engine engine, 
            Cargo cargo, 
            Tire[] tires)
        {
            return new Car(model, engine, cargo, tires);
        }
    }
}