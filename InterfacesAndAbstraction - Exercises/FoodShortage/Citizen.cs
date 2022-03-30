using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthdate { get; private set; }
        public int Food { get; private set; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            Food = 0;
        }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
