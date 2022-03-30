using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.FoodClasses;

namespace WildFarm.AnimalClasses
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }
        public override void GetSound()
        {
            Console.WriteLine("Woof!");
        }
        public override void Eat(Food food)
        {
            if (!(food is Meat))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.Quantity * 0.4;
            this.FoodEaten += food.Quantity;
        }
    }
}
