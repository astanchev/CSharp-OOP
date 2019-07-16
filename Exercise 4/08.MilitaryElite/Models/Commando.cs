namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using Contracts;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => this.missions.AsReadOnly();
        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString())
                .AppendLine("Missions:");

            foreach (var mission in this.Missions)
            {
                result.AppendLine("  " + mission.ToString().TrimEnd());
            }

            return result.ToString().TrimEnd();
        }
    }
}