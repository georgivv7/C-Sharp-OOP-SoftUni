using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var heroFactory = new HeroFactory();
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> raid = new List<BaseHero>();

            for (int i = 0; i < n; i++)
            {
                BaseHero hero = null;
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                try
                {
                    hero = heroFactory.GetHero(heroType, heroName);
                    raid.Add(hero);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }             
            }

            int bossPower = int.Parse(Console.ReadLine());
            int raidSum = raid.Sum(item => item.Power);

            raid.ForEach(x => Console.WriteLine(x.CastAbility()));

            if (raidSum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
