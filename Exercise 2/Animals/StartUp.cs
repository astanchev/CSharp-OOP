namespace Animals
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        private static List<Animal> animals;
        public static void Main()
        {
            GetAnimals();
            
            Console.WriteLine(string.Join(Environment.NewLine, animals));
        }

        private static void GetAnimals()
        {
            animals = new List<Animal>();
           
            while (true)
            {
                var kind = Console.ReadLine();
                if (kind == "Beast!")
                {
                    break;
                }
                
                string[] animalDetails = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = animalDetails[0];
                int age = int.Parse(animalDetails[1]);
                string gender = animalDetails[2];

                try
                {
                    var animal = AnimalFactory.GetAnimal(kind, name, age, gender);
                    animals.Add(animal);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
