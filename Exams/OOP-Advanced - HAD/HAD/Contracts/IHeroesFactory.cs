namespace HAD.Contracts
{
    using HAD.Entities.Heroes;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IHeroesFactory
    {
        IHero CreateHero(string name, string type);
    }
}
