namespace MXGP.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Motorcycles;
    using Models.Motorcycles.Contracts;
    using Models.Races;
    using Models.Races.Contracts;
    using Models.Riders;
    using Models.Riders.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        private RaceRepository races;
        private MotorcycleRepository motorcycles;
        private RiderRepository riders;

        public ChampionshipController()
        {
            races = new RaceRepository();
            motorcycles = new MotorcycleRepository();
            riders = new RiderRepository();
        }

        public string CreateRider(string riderName)
        {
            IRider rider = new Rider(riderName);
            if (riders.GetAll().Any(r => r.Name == riderName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RiderExists, riderName));
            }

            riders.Add(rider);

            return String.Format(OutputMessages.RiderCreated, riderName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = null;

            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            else if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }

            if (motorcycles.GetAll().Any(m => m.Model == model))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.MotorcycleExists, model));
            }

            motorcycles.Add(motorcycle);

            return String.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (races.GetAll().Any(r => r.Name == name))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);

            races.Add(race);
            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            if (races.GetAll().All(r => r.Name != raceName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (riders.GetAll().All(r => r.Name != riderName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            IRider rider = riders.GetAll().First(r => r.Name == riderName);

            IRace race = races.GetAll().First(r => r.Name == raceName);

            race.AddRider(rider);

            return String.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            if (riders.GetAll().All(r => r.Name != riderName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            if (motorcycles.GetAll().All(m => m.Model != motorcycleModel))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            IRider rider = riders.GetAll().First(r => r.Name == riderName);
            IMotorcycle mot = motorcycles.GetAll().First(m => m.Model == motorcycleModel);

            rider.AddMotorcycle(mot);

            return String.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string StartRace(string raceName)
        {
            if (races.GetAll().All(r => r.Name != raceName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IRace race = races.GetAll().First(r => r.Name == raceName);
            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            List<IRider> winners = race.Riders.OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps)).Take(3).ToList();

            //Forgotten
            winners[0].WinRace();

            StringBuilder result = new StringBuilder();

            result.AppendLine(String.Format(OutputMessages.RiderFirstPosition, winners[0].Name, race.Name))
                .AppendLine(String.Format(OutputMessages.RiderSecondPosition, winners[1].Name, race.Name))
                .AppendLine(String.Format(OutputMessages.RiderThirdPosition, winners[2].Name, race.Name));

            //Forgotten
            races.Remove(race);

            return result.ToString().TrimEnd();
        }
    }
}