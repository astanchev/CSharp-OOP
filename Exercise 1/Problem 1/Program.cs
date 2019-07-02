namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    
    class RawData
    {
        static void Main(string[] args)
        {
            EngineFactory engineFactory = new EngineFactory();
            CargoFactory cargoFactory = new CargoFactory();
            CarFactory carFactory = new CarFactory();
            CarCatalogue carCatalogue = new CarCatalogue(
                                                 engineFactory, 
                                                 cargoFactory,
                                                 carFactory);
            
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                carCatalogue.Add(parameters);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = carCatalogue.GetCars()
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = carCatalogue.GetCars()
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
