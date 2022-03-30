using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Repair : IRepair
    {
        public string PartName { get; private set; }
        public int HoursWorked { get; private set; }

        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }
        public override string ToString()
        {
            return string.Format($"Part Name: {PartName} Hours Worked: {HoursWorked}");
        }
    }
}
