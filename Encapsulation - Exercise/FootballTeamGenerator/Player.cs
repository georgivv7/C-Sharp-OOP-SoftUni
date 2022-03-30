using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
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
        public int Endurance 
        {
            get { return this.endurance; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");
                }
                this.endurance = value;
            } 
        }
        public int Sprint
        {
            get { return this.sprint; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");
                }
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get { return this.dribble; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Dribble)} should be between 0 and 100.");
                }
                this.dribble = value;
            }
        }
        public int Passing
        {
            get { return this.passing; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
                }
                this.passing = value;
            }
        }
        public int Shooting
        {
            get { return this.shooting; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
                }
                this.shooting = value;
            }
        }
        public int Skill()
        {
            return (int)Math.Round((this.Passing + this.Dribble + this.Endurance + this.Shooting + this.Sprint) / 5.0);
        }
    }
}
