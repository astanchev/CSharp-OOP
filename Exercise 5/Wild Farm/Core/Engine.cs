namespace WildFarm.Core
{
    using Models.Animals;
    using System;
    using System.Collections.Generic;
    using Models.Factories;
    using Models.Foods;
    public class Engine
    {
        private static List<Animal> animals;
        public Engine()
        {
            animals = new List<Animal>();
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

                string[] animalArgs = input.Split();

                Animal animal = AnimalFactory.CreateAnimal(animalArgs);

                string[] foodArgs = Console.ReadLine().Split();

                Food food = FoodFactory.CreateFood(foodArgs);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}