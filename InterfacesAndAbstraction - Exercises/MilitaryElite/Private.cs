using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite
{
    public class Private : Soldier,IPrivate
    {
        public double Salary { get; private set; }

        public Private(int id,string firstName, string lastName,double salary)
            : base(id,firstName, lastName)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return string.Format($"{base.ToString()} Salary: {Salary:F2}");
        }
    }
}
