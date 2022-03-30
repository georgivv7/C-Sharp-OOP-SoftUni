using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        private string userName;
        private int level;

        public Hero(string username, int level)
        {
            this.UserName = username;
            this.Level = level;
        }
        public string UserName 
        {
            get { return this.userName; }
            set { this.userName = value; }
        }
        public int Level 
        {
            get { return this.level; }
            set { this.level = value; }
        }
        public override string ToString()
        {
            return string.Format($"Type: {this.GetType().Name} Username: {this.UserName} Level: {this.Level}");
        }
    }
}
