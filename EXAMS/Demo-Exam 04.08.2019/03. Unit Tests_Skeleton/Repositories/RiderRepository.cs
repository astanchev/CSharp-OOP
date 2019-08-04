namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Riders.Contracts;

    public class RiderRepository : IRepository<IRider>
    {
        private List<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }

        public IRider GetByName(string name)
        {
            return this.riders.FirstOrDefault(r => r.Name == name);
        }

        public IReadOnlyCollection<IRider> GetAll() => this.riders.AsReadOnly();

        public void Add(IRider model)
        {
            this.riders.Add(model);
        }

        public bool Remove(IRider model) => this.riders.Remove(model);
           
    }
}