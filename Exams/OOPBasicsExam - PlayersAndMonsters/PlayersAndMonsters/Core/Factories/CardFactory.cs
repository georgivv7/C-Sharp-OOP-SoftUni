namespace PlayersAndMonsters.Core.Factories
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            var typeCard = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type + "Card");

            if (typeCard == null)
            {
                throw new ArgumentNullException();
            }

            var newCard = (ICard)Activator.CreateInstance(typeCard, name);
            return newCard;          
        }
    }
}
