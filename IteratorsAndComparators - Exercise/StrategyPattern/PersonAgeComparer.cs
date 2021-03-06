using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StrategyPattern
{
    public class PersonAgeComparer : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson) 
        {
            return firstPerson.Age.CompareTo(secondPerson.Age);
        }
    }
}
