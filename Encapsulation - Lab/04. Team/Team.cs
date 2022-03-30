using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        public Team(string name)
        {
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
            this.Name = name;
        }
        public string Name { get { return this.name; } set { this.name = value; } }
        public List<Person> FirstTeam
        {
            get { return this.firstTeam; }
        }
        public List<Person> ReserveTeam
        {
            get { return this.reserveTeam; }
        }


        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                this.firstTeam.Add(player);
            }
            else
            {
                this.reserveTeam.Add(player);
            }
        }
    }
}
