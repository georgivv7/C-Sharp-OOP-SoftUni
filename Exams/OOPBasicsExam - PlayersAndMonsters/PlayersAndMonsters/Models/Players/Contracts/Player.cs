namespace PlayersAndMonsters.Models.Players.Contracts
{
    using PlayersAndMonsters.Common;
    using System;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private ICardRepository cardRepository;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }
        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ConstantMessages.InvalidUsername);
                }
                this.username = value;
            }
        }
        public int Health
        {
            get { return this.health; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ConstantMessages.InvalidHealth);
                }
                this.health = value;
            }
        }
        public ICardRepository CardRepository
        {
            get { return this.cardRepository; }
            private set { this.cardRepository = value; }
        }
        public bool IsDead => this.Health == 0;
        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException(ConstantMessages.InvalidDamagePoints);
            }
            if (this.Health - damagePoints > 0)
            {
                this.Health -= damagePoints;
            }
            else
            {
                this.Health = 0;
            }
            
        }
    }
}
