using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite
{
    public abstract class SpecializedSoldier : Private, ISpecializedSoldier
    {
        public SpecializedSoldier(int id, string firstName, string lastName, double salary,string corps)
            :base(id,firstName,lastName,salary)
        {
            ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private void ParseCorps(string corps)
        {
            bool validCorps = Enum.TryParse(typeof(Corps), corps, out object outCorps);
            if (validCorps == false)
            {
                throw new ArgumentException($"Invalid corps!");
            }
            this.Corps = (Corps)outCorps;
        }
        
    }
}
