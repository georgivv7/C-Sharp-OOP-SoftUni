using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StrategyPattern   
{
    public class Person
    {
        public string Name { get; }
        public int Age { get; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
