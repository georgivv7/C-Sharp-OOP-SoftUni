namespace PlayersAndMonsters.Core.Factories
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class PlayerFactory : IPlayerFactory
    {   
        public IPlayer CreatePlayer(string type, string username)
        {
            var typePlayer = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);
                       
            if (typePlayer == null)
            {
                throw new ArgumentNullException();
            }

            ICardRepository cardRepository = new CardRepository();
            var newPlayer = (IPlayer)Activator.CreateInstance(typePlayer, cardRepository, username);
            return newPlayer;
        }
    }
}
