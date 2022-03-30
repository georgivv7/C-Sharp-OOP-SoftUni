namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class CardRepository : ICardRepository
    {
        private IList<ICard> cards;
        public CardRepository()
        {
            this.cards = new List<ICard>();
        }
        public int Count => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards => (IReadOnlyCollection<ICard>)this.cards;

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ConstantMessages.InvalidCard);
            }
            if (this.cards.Any(n=>n.Name == card.Name))
            {
                throw new ArgumentException(string.Format(ConstantMessages.CardExists, card.Name));
            }
            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            var card = this.cards.FirstOrDefault(n => n.Name == name);
            return card;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ConstantMessages.InvalidCard);
            }

            return this.cards.Remove(card);
        }
    }
}
