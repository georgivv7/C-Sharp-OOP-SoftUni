using System;
using System.Collections.Generic;
using System.Text;

namespace WorkForce
{
    public class PartTimeEmployee : Employee
    {
        private const int HoursPerWeek = 20;
        public PartTimeEmployee(string name) : base(name, HoursPerWeek)
        {
        }
    }
}
