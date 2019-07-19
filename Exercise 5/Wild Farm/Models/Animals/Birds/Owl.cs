namespace WildFarm.Models.Animals.Birds
{
    using System.Collections.Generic;
    using Foods;
    public class Owl : Bird
    {
        private const double GainValue = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>(){nameof(Meat)}, GainValue);
        }
    }
}