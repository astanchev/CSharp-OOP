namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Motorcycles;
    using Models.Motorcycles.Contracts;

    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private List<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }

        public IMotorcycle GetByName(string name)
        {
            return this.motorcycles.FirstOrDefault(m => m.Model == name);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll() => this.motorcycles.AsReadOnly();

        public void Add(IMotorcycle model)
        {
            if (motorcycles.All(m => m.Model != model.Model))
            {
                this.motorcycles.Add(model);

            }
        }

        public bool Remove(IMotorcycle model) => this.motorcycles.Remove(model);
    }
}