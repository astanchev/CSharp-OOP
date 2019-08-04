namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Races.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public IRace GetByName(string name)
        {
            return this.races.FirstOrDefault(r => r.Name == name);
        }

        public IReadOnlyCollection<IRace> GetAll() => this.races.AsReadOnly();

        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public bool Remove(IRace model)=> this.races.Remove(model);
        
    }
}