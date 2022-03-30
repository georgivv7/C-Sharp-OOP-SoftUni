using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.AnimalClasses
{
    public abstract class Feline : Mammal
    {
        public string Breed { get; private set; }
        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public override string ToString()
        {
            return string.Format($"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]");
        }
    }
}
