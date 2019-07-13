namespace FoodShortage.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Factories;
    using Interfaces;

    public class Engine
    {
        private List<IBuyer> population;
        public Engine()
        {
            population = new List<IBuyer>();
        }

        public void Run()
        {
            int numberInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberInputs; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();

                if (commandArgs.Length == 4)
                {
                    IBuyer citizen = CitizenFactory.CreateCitizen(commandArgs);

                    population.Add(citizen);
                }
                else if (commandArgs.Length == 3)
                {
                    IBuyer rebel = RebelFactory.CreateRebel(commandArgs);

                    population.Add(rebel);
                }
            }

            
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                IBuyer buyer = population.FirstOrDefault(b => b.Name == input);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(population.Sum(b => b.Food));
        }
    }
}