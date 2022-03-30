using PlayersAndMonsters.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards.Contracts
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ConstantMessages.InvalidCardName);
                }
                this.name = value;
            }
        }       
        public int DamagePoints 
        {
            get { return damagePoints; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ConstantMessages.InvalidCardDamagePoints);
                }
                this.damagePoints = value; 
            }
        }
        

        public int HealthPoints 
        {
            get { return healthPoints; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ConstantMessages.InvalidCardHealth);
                }
                this.healthPoints = value; 
            }
        }
    }
}
