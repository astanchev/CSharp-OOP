namespace MilitaryElite.Factories
{
    using Core;
    using Exceptions;
    using Models;
    using System;
    using System.Linq;
    public static class ArmyFactory
    {
        public static void AddPrivateToArmy(string id, string firstName, string lastName, decimal salary)
        {
            Private @private = PrivateFactory.CreatePrivate(id, firstName, lastName, salary);

            Engine.army.Add(@private);
        }

        public static void AddLtGeneralToArmy(string id, string firstName, string lastName, decimal salary, string[] args)
        {
            LieutenantGeneral ltGeneral =
                LieutenantGeneralFactory.CreateLieutenantGeneral(id, firstName, lastName, salary);

            AddPrivatesToLtGeneral(args, ltGeneral);

            Engine.army.Add(ltGeneral);
        }

        private static void AddPrivatesToLtGeneral(string[] args, LieutenantGeneral ltGeneral)
        {
            foreach (var pId in args)
            {
                if (Engine.army.First(s => s.Id == pId) is Private privateToAdd)
                {
                    ltGeneral.AddPrivate(privateToAdd);
                }
            }
        }

        public static void AddEngineerToArmy(string[] args, string id, string firstName, string lastName, decimal salary)
        {
            try
            {
                string corpsE = args[0];

                Engineer engineer = EngineerFactory.CreateEngineer(id, firstName, lastName, salary, corpsE);

                AddRepairsToEngeneer(args, engineer);

                Engine.army.Add(engineer);
            }
            catch (InvalidCorpseException ice)
            {
            }

            return;
        }

        private static void AddRepairsToEngeneer(string[] args, Engineer engineer)
        {
            string[] repairArgs = args.Skip(1).ToArray();

            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                string partName = repairArgs[i];
                int hours = Int32.Parse(repairArgs[i + 1]);

                Repair repair = RepairFactory.CreateRepair(partName, hours);

                engineer.AddRepair(repair);
            }
        }

        public static void AddCommandoToArmy(string[] args, string id, string firstName, string lastName, decimal salary)
        {
            try
            {
                string corpsC = args[0];

                Commando commando = CommandoFactory.CreateCommando(id, firstName, lastName, salary, corpsC);

                string[] missionArgs = args.Skip(1).ToArray();
                for (int i = 0; i < missionArgs.Length; i += 2)
                {
                    Mission mission;

                    try
                    {
                        string codeName = missionArgs[i];
                        string state = missionArgs[i + 1];

                        mission = MissionFactory.CreateMission(codeName, state);

                        commando.AddMission(mission);
                    }
                    catch (InvalidStateExceprion ise)
                    {
                        continue;
                    }
                }

                Engine.army.Add(commando);
            }
            catch (InvalidCorpseException ice)
            {
            }
        }
        public static void AddSpyToArmy(decimal salary, string id, string firstName, string lastName)
        {
            int codeNameSpy = (int)salary;

            Spy spy = SpyFactory.CreateSpy(id, firstName, lastName, codeNameSpy);

            Engine.army.Add(spy);
        }
    }
}