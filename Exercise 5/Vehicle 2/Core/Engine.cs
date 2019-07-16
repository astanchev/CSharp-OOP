namespace Vehicles.Core
{
    using Factories;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private static List<Vehicle> vehicles;
        public Engine()
        {
            vehicles = new List<Vehicle>();
        }

        public void Run()
        {
            AddVehicles();

            ManageVehicles();

            PrintVehicles();
        }

        private static void ManageVehicles()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];
                string vehicle = input[1];
                double value = double.Parse(input[2]);

                if (command == "Drive")
                {
                    DriveVehicle(value, vehicle);
                }
                else if (command == "Refuel")
                {
                    try
                    {
                        RefuelVehicle(value, vehicle);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
                else if (command == "DriveEmpty")
                {
                    DriveEmptyBus(value, vehicle);
                }
            }
        }

        private static void PrintVehicles()
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        private void AddVehicles()
        {
            for (int i = 1; i <= 3; i++)
            {
                string[] vehicleArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Vehicle vehicle = null;

                if (i == 1)
                {
                    vehicle = CarFactory.CreateCar(vehicleArgs);
                }
                else if (i == 2)
                {
                    vehicle = TruckFactory.CreateTruck(vehicleArgs);
                }
                else
                {
                    vehicle = BusFactory.CreateBus(vehicleArgs);
                }

                vehicles.Add(vehicle);
            }
        }

        private static void DriveEmptyBus(double distance, string vehicle)
        {
            Bus currentBus = (Bus)vehicles.First(v => v.GetType().Name == vehicle);

            Console.WriteLine(currentBus.DriveEmpty(distance));
        }

        private static void RefuelVehicle(double ammountFuel, string vehicle)
        {
            Vehicle currentVehicle = vehicles.First(v => v.GetType().Name == vehicle);

            currentVehicle.Refuel(ammountFuel);
        }

        private static void DriveVehicle(double distance, string vehicle)
        {
            Vehicle currentVehicle = vehicles.First(v => v.GetType().Name == vehicle);

            Console.WriteLine(currentVehicle.Drive(distance));
        }
    }
}