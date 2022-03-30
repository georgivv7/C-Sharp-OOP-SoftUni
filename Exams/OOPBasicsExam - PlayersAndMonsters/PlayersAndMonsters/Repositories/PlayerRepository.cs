namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class PlayerRepository : IPlayerRepository
    {
        private IList<IPlayer> players;
        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public int Count => this.players.Count;

        public IReadOnlyCollection<IPlayer> Players => (IReadOnlyCollection<IPlayer>)this.players;

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ConstantMessages.InvalidPlayer);
            }
            var playerName = this.players.FirstOrDefault(n => n.Username == player.Username);
            if (!(playerName == null))
            {
                throw new ArgumentException(string.Format(ConstantMessages.PlayerExists, player.Username));
            }
            this.players.Add(player);
        }
        public IPlayer Find(string username)
        {
            var player = this.players.FirstOrDefault(n => n.Username == username);
            return player;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ConstantMessages.InvalidPlayer);
            }          
            return this.players.Remove(player);
        }
    }
}
