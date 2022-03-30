using System;
using System.Collections.Generic;
using System.Text;

namespace WorkForce
{
    public class StandardEmployee : Employee
    {
        private const int HoursPerWeek = 40;
        public StandardEmployee(string name) : base(name, HoursPerWeek)
        {
        }
    }
}
