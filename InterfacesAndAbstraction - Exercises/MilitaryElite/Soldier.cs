using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite
{
    public abstract class Soldier : ISoldier
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Id { get; private set; }

        public Soldier(int id,string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;         
        }

        public override string ToString()
        {
            return string.Format($"Name: {FirstName} {LastName} Id: {Id}");
        }
    }
}
