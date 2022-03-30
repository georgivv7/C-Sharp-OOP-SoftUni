namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> models;
        public RaceRepository()
        {
            this.models = new List<IRace>();
        }
        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
           return this.models.AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Name == name);
        }

        public bool Remove(IRace model)
        {
            return this.models.Remove(model);
        }
    }
}
