namespace WildFarm.Models.Animals.Mammals
{
    using Foods;
    using System.Collections.Generic;
    public class Mouse : Mammal
    {
        private const double GainValue = 0.1;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>(){nameof(Vegetable), nameof(Fruit)}, GainValue);
        }
    }
}