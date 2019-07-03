namespace P05_GreedyTimes
{
    public class Cash
    {
        public string Name { get; private set; }

        public long Amount { get; set; }

        public Cash(string name)
        {
            Name = name;
            this.Amount = 0;
        }
    }
}