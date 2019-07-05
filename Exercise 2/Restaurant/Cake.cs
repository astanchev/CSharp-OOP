namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double CakeGrams = 250.0;
        private const double CakeCalories = 1000.0;
        private const decimal CakePrice = 5.0m;

        public Cake(string name) 
            : base(name, CakePrice, CakeGrams, CakeCalories)
        {
        }
    }
}