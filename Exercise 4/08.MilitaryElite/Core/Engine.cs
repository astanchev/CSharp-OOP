namespace MilitaryElite.Core
{
    using Factories;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        internal static List<Soldier> army;
        public Engine()
        {
            army = new List<Soldier>();
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
                string typeSoldier = commandArgs[0];
                string id = commandArgs[1];
                string firstName = commandArgs[2];
                string lastName = commandArgs[3];
                decimal salary = decimal.Parse(commandArgs[4]);
                string[] args = commandArgs.Skip(5).ToArray();

                switch (typeSoldier)
                {
                    case "Private":
                        ArmyFactory.AddPrivateToArmy(id, firstName, lastName, salary);
                        break;
                    case "LieutenantGeneral":
                        ArmyFactory.AddLtGeneralToArmy(id, firstName, lastName, salary, args);
                        break;
                    case "Engineer":
                        ArmyFactory.AddEngineerToArmy(args, id, firstName, lastName, salary);
                        break;
                    case "Commando":
                        ArmyFactory.AddCommandoToArmy(args, id, firstName, lastName, salary);
                        break;
                    case "Spy":
                        ArmyFactory.AddSpyToArmy(salary, id, firstName, lastName);
                        break;
                    default:
                        break;
                }
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var soldier in army)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}