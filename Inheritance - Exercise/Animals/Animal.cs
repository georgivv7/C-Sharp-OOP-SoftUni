using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }
        public string Gender
        {
            get { return this.gender; }
            private set
            {
                if (value == "Male" || value == "Female")
                {
                    this.gender = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }

            }
        }
        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            return string.Format($"{this.Name} {this.Age} {this.Gender}");
        }
    }
}
