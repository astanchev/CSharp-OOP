namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    public class Dough
    {
        private const double caloriesPerGram = 2.0;
        
        private string flourType;
        private string bakingTechnique;
        private double weight;
        private Dictionary<string, double> doughModifiers;
        
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
            this.FillModifiers();
        }

        public string FlourType
        {
            get => this.flourType;
            set
            {
                if (value.ToLower() == "white" 
                    || value.ToLower() == "wholegrain")
                {
                    this.flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            set
            {
                if (value.ToLower() == "crispy"
                    || value.ToLower() == "chewy"
                    || value.ToLower() == "homemade")
                {
                    this.bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public double Weight
        {
            get => this.weight;
            set
            {
                if (value >= 1 && value <= 200)
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }

        public void FillModifiers()
        {
            this.doughModifiers = new Dictionary<string, double>()
            {
                {"white", 1.5},
                {"wholegrain", 1.0},
                {"crispy", 0.9},
                {"chewy", 1.1},
                {"homemade", 1.0}
            }; 
        }

        public double GetTotalCalories()
        {
            // This is decision with Reflection:

            //double flourTypeModifier = (double)typeof(DoughModifiers).GetField(flourType).GetValue(null);

            //double bakingTechniqueModifier = (double)typeof(DoughModifiers).GetField(bakingTechnique).GetValue(null);

            return caloriesPerGram * this.Weight * doughModifiers[flourType.ToLower()] * doughModifiers[bakingTechnique.ToLower()];
        }
    }
}