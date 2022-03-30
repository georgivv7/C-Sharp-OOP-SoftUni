using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
    
namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; }
        public int Age { get; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            //if (result == 0)
            //{
            //    result = this.Town.CompareTo(other.Town);
            //}
            return result;
        }
        public override bool Equals(object obj)
        {
            if (obj is Person other)
            {
                return this.Name == other.Name && this.Age == other.Age;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
