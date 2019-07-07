namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Topping
    {
        private const double CaloriesPerGram = 2.0;
         
        private string toppingType;
        private double weight;
        private Dictionary<string, double> toppingModifiers;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
            this.FillModifiers();
        }

        public string ToppingType
        {
            get => this.toppingType;
            set
            {
                if (value.ToLower() == "meat" 
                    || value.ToLower() == "veggies"
                    || value.ToLower() == "cheese"
                    || value.ToLower() == "sauce")
                {
                    this.toppingType = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        public double Weight
        {
            get => this.weight;
            set
            {
                if (value >= 1 && value <= 50)
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }
            }
        }
        public void FillModifiers()
        {
            this.toppingModifiers = new Dictionary<string, double>()
            {
                {"meat", 1.2},
                {"veggies", 0.8},
                {"cheese", 1.1},
                {"sauce", 0.9}
            }; 
        }

        public double GetTotalCalories()
        {
            
            return CaloriesPerGram * this.Weight * toppingModifiers[toppingType.ToLower()];
        }
    }
}