namespace _10.ExplicitInterfaces.Core
{
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;


    public class Engine
    {
        private List<Citizen> citizens;
        public Engine()
        {
            citizens = new List<Citizen>();
        }

        public void Run()
        {
            AddCitizens();

            foreach (var citizen in citizens)
            {
                Console.WriteLine(citizen.GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }

        private void AddCitizens()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }

                string name = input[0];
                string country = input[1];
                int age = int.Parse(input[2]);

                Citizen citizen = new Citizen(name, country, age);

                citizens.Add(citizen);
            }
        }
    }
}