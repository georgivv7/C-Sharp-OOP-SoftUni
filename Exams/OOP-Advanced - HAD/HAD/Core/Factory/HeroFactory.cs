namespace HAD.Core.Factory
{
    using System;
    using System.Linq;
    using System.Reflection;
    using HAD.Contracts;
    using HAD.Core.Factory.Contracts;
    using HAD.Entities.Heroes;
    public class HeroFactory : IHeroFactory
    {
        public IHero CreateHero(string heroType,string name)
        {
            var assembly = Assembly.GetCallingAssembly();
            var type = assembly.GetTypes().FirstOrDefault(t => t.Name == heroType);

            IHero hero = (IHero)Activator.CreateInstance(type, name);
            return hero;
        }
    }
}
