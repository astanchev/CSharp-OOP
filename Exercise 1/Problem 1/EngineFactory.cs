namespace P01_RawData
{
    public class EngineFactory
    {
        public Engine Create(int speed, int power)
        {
            return new Engine(speed, power);
        }
    }
}