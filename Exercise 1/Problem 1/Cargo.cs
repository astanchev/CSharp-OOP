namespace P01_RawData
{
    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }

        public string Type { get; private set; }

        public int Weight { get; private set; }
    }
}