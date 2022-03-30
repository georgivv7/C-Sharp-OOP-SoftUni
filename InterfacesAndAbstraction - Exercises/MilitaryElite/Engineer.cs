using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite
{
    public class Engineer : SpecializedSoldier,IEngineer
    {
        private ICollection<IRepair> repairs;
        public Engineer(int id, string firstName, string lastName, double salary, string corps)
            :base(id,firstName,lastName,salary,corps)
        {
            repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>)repairs;

        public void AddRepair(IRepair repair)
        {
            repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString())
                   .AppendLine($"{nameof(Corps)}: {Corps.ToString()}")
                   .AppendLine($"{nameof(Repairs)}:");

            foreach (var repair in Repairs)
            {
                builder.AppendLine($"  {repair.ToString()}");
            }
            string result = builder.ToString().TrimEnd();
            return result;
        }
    }
}
