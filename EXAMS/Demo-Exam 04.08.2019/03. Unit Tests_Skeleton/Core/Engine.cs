namespace MXGP.Core
{
    using System;
    using System.Text;
    using Contracts;

    public class Engine : IEngine
    {
        private ChampionshipController controller;

        public Engine()
        {
            controller = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }

                StringBuilder result = new StringBuilder();

                string command = input[0];

                try
                {
                    switch (command)
                    {
                        case "CreateRider":
                        {
                            string name = input[1];

                            result.AppendLine(controller.CreateRider(name));
                        }
                            break;

                        case "CreateMotorcycle":
                        {
                            string type = input[1];
                            string model = input[2];
                            int horsePower = int.Parse(input[3]);

                            result.AppendLine(controller.CreateMotorcycle(type, model, horsePower));
                        }
                            break;

                        case "AddMotorcycleToRider":
                        {
                            string riderName = input[1];
                            string motoName = input[2];

                            result.AppendLine(controller.AddMotorcycleToRider(riderName, motoName));
                        }
                            break;

                        case "AddRiderToRace":
                        {
                            string raceName = input[1];
                            string riderName = input[2];

                            result.AppendLine(controller.AddRiderToRace(raceName, riderName));
                        }
                            break;

                        case "CreateRace":
                        {
                            string name = input[1];
                            int laps= int.Parse(input[2]);

                            result.AppendLine(controller.CreateRace(name, laps));
                        }
                            break;

                        case "StartRace":
                        {
                            string name = input[1];

                            result.AppendLine(controller.StartRace(name));
                        }
                            break;

                        default: break;
                    }
                }
                catch (Exception e)
                {
                    result.AppendLine(e.Message);
                }

                Console.WriteLine(result.ToString().TrimEnd());
            }
        }

    }
}