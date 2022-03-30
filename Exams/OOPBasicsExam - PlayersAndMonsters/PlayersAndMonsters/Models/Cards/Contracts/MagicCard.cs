using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards.Contracts
{
    public class MagicCard : Card
    {
        private const int defaultHealth = 80;
        private const int defaultDamage = 5;
        public MagicCard(string name)
            : base(name, defaultDamage, defaultHealth)
        {
        }
    }
}
