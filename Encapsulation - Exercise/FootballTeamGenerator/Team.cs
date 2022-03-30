using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;
        public Team(string name)
        {
            this.Name = name;
            this.Players = new List<Player>();
        }
        public int Count => this.Players.Count;
        public string Name 
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            } 
        }
        public List<Player> Players
        {
            get { return this.players; }
            set { this.players = value; }
        }

        public int Rating()
        {
            if (this.Count == 0)
            {
                return 0;
            }
            return (int)Math.Round(this.Players.Select(x => x.Skill()).Sum() / (double)this.Count);
        }

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            bool containsPlayer = this.Players.Any(p => p.Name == playerName);
            if (containsPlayer == false)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
            Player player = this.Players.First(x => x.Name == playerName);
            this.Players.Remove(player);
        }
    }
}
