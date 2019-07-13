using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using FoodShortage.Factories;
using FoodShortage.Interfaces;

namespace FoodShortage.Core
{
    public class Engine
    {
        private List<IIdentifiable> population;
        public Engine()
        {
            population = new List<IIdentifiable>();
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

                if (commandArgs.Length == 3)
                {
                    IIdentifiable citizen = CitizenFactory.CreateCitizen(commandArgs);

                    population.Add(citizen);
                }
                else if (commandArgs.Length == 2)
                {
                    IIdentifiable robot = RobotFactory.CreateRobot(commandArgs);

                    population.Add(robot);
                }
            }

            string fakeIdEnd = Console.ReadLine();

            foreach (var identifiable in population)
            {
                if (identifiable.Id.EndsWith(fakeIdEnd))
                {
                    Console.WriteLine(identifiable.Id);
                }
            }
        }
    }
}