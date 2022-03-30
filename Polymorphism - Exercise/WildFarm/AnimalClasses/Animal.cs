using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.AnimalClasses
{
    public abstract class Animal
    {
        public string Name { get; private set; }
        public double Weight { get;  set; }
        public int FoodEaten { get;  set; }
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public abstract void GetSound();
        public abstract void Eat(Food food);
    }
}
