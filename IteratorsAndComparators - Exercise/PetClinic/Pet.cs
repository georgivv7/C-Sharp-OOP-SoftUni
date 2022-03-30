using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic
{
    public class Pet
    {
        public Pet(string name, int age, string kind)
        {
            Name = name;
            Age = age;
            Kind = kind;
        }
        public string Name { get; }
        public int Age { get; }
        public string Kind { get; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Kind}";
        }
    }
}
