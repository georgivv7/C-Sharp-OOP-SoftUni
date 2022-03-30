using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite
{
    public class LeutenantGeneral : Private,ILeutenantGeneral
    {
        private ICollection<ISoldier> privates;

        public LeutenantGeneral(int id,string firstname, string lastname, double salary)
            : base(id,firstname, lastname,salary)
        {
            privates = new List<ISoldier>();
        }
        public IReadOnlyCollection<ISoldier> Privates => (IReadOnlyCollection<ISoldier>)privates;
        public void AddPrivate(ISoldier soldier)
        {
            privates.Add(soldier);
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString())
                   .AppendLine($"{nameof(Privates)}: ");

            foreach (var @private in Privates)
            {
                builder.AppendLine($"  {@private.ToString()}");
            }
            string result = builder.ToString().TrimEnd();
            return result;
        }
    }
}
