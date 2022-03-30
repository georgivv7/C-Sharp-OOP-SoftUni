using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.AnimalClasses
{
    public abstract class Mammal : Animal
    {
        public string LivingRegion { get; private set; }
        public Mammal(string name, double weight, string livingRegion)
            :base(name,weight)
        {
            LivingRegion = livingRegion;
        }

        public override string ToString()
        {
            return string.Format($"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]");
        }
    }
}
