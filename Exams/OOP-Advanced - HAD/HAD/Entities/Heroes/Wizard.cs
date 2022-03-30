namespace HAD.Entities.Heroes
{
    public class Wizard : BaseHero
    {
        private const int BaseHeroStrength = 25;
        private const int BaseHeroAgility = 25;
        private const int BaseHeroIntelligence = 100;
        private const int BaseHeroHitPoints = 100;
        private const int BaseHeroDamage = 250;
        public Wizard(string name):
            base(name,
                BaseHeroStrength,
                BaseHeroAgility,
                BaseHeroIntelligence,
                BaseHeroHitPoints,
                BaseHeroDamage)
        { }
    }
}
