﻿namespace WildFarm.Models.Animals.Mammals.Felines
{
    using Foods;
    using System.Collections.Generic;
    public class Cat : Feline
    {
        private const double GainValue = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>(){nameof(Vegetable), nameof(Meat)}, GainValue);
        }
    }
}