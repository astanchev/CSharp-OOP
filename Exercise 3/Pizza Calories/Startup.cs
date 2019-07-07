using System.Collections.Generic;

namespace PizzaCalories
{
    using System;
    public class Startup
    {
        public static void Main(string[] args)
        {
            try
            {
                Pizza pizza = MakePizza();

                AddToppings(pizza);

                Console.WriteLine(pizza);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private static Pizza MakePizza()
        {
            string[] inputPizza = Console.ReadLine().Split();
            string pizzaName = inputPizza[1];

            Dough dough = MakeDough();

            Pizza pizza = new Pizza(pizzaName, dough);
            return pizza;
        }

        private static Dough MakeDough()
        {
            string[] inputDough = Console.ReadLine().Split();
            string doughFlourType = inputDough[1];
            string doughBakingTechnique = inputDough[2];
            double doughWeight = double.Parse(inputDough[3]);

            Dough dough = new Dough(doughFlourType, doughBakingTechnique, doughWeight);

            return dough;
        }

        private static void AddToppings(Pizza pizza)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] inputTopping = input.Split();

                string toppingType = inputTopping[1];
                double toppingWeight = double.Parse(inputTopping[2]);

                Topping topping = new Topping(toppingType, toppingWeight);

                pizza.AddToppings(topping);
            }
        }
    }
}
