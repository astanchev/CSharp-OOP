namespace FoodShortage.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Factories;
    using Interfaces;

    public class Engine
    {
        private List<IBirthable> population;
        public Engine()
        {
            population = new List<IBirthable>();
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] commandArgs = input.Split();
                string individ = commandArgs[0];

                if (individ == "Citizen")
                {
                    IBirthable citizen = CitizenFactory.CreateCitizen(commandArgs.Skip(1).ToArray());

                    population.Add(citizen);
                }
                else if (individ == "Pet")
                {
                    IBirthable pet = PetFactory.CreatePet(commandArgs.Skip(1).ToArray());

                    population.Add(pet);
                }
            }

            string yearToShow = Console.ReadLine();

            foreach (var birthable in population)
            {
                if (birthable.Birthdate.EndsWith(yearToShow))
                {
                    Console.WriteLine(birthable.Birthdate);
                }
            }
        }
    }
}