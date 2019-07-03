namespace P05_GreedyTimes
{
    public class Gem
    {
        public string Name { get; private set; }

        public long Amount { get; set; }

        public Gem(string name)
        {
            this.Name = name;
            this.Amount = 0;
        }
    }
}