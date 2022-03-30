using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StrategyPattern
{
    public class PersonNameComparer : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            int firstPersonLength = firstPerson.Name.Length;
            int secondPersonLength = secondPerson.Name.Length;
            int result = firstPersonLength.CompareTo(secondPersonLength);

            if (result == 0)
            {
                char firstPersonLetter = Char.ToLower(firstPerson.Name[0]);
                char secondPersonLetter = Char.ToLower(secondPerson.Name[0]);
                result = firstPersonLetter.CompareTo(secondPersonLetter);
            }

            return result;
        }
    }
}
