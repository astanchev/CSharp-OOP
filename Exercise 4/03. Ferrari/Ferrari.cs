using System.Text;

namespace Ferrari
{
    public class Ferrari : ICar
    {
        private string model = "488-Spider";
        private string driver;

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Driver
        {
            get => this.driver; 
            private set => this.driver = value;
        }
        
        public string HitBreaks()
        {
            return "Brakes!";
        }

        public string PushGasPedal()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.model}/{this.HitBreaks()}/{this.PushGasPedal()}/{this.Driver}");

            return sb.ToString().TrimEnd();
        }
    }
}