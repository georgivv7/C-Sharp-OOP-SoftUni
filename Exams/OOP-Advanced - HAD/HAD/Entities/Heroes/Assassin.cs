namespace HAD.Entities.Heroes
{
    public class Assassin : BaseHero
    {
        private const int BaseHeroStrength = 25;
        private const int BaseHeroAgility = 100;
        private const int BaseHeroIntelligence = 15;
        private const int BaseHeroHitPoints = 150;
        private const int BaseHeroDamage = 300;
        public Assassin(string name) 
            : base(name,
                  BaseHeroStrength,
                  BaseHeroAgility,
                  BaseHeroIntelligence,
                  BaseHeroHitPoints,
                  BaseHeroDamage)
        { }
    }
}
