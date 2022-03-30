namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> models;
        public CarRepository()
        {
            this.models = new List<ICar>();
        }
        public void Add(ICar model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.models.AsReadOnly();
        }

        public ICar GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Model == name);
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }
    }
}
