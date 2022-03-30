using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards.Contracts
{
    public class TrapCard : Card
    {
        private const int defaultHealth = 5;
        private const int defaultDamage = 120;
        public TrapCard(string name)
            : base(name, defaultDamage, defaultHealth)
        {

        }
    }
}
