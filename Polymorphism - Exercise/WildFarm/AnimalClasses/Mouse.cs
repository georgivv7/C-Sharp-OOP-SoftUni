using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.FoodClasses;

namespace WildFarm.AnimalClasses
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            :base(name,weight,livingRegion)
        {

        }
        public override void GetSound()
        {
            Console.WriteLine("Squeak");
        }
        public override void Eat(Food food)
        {
            if (!(food is Vegetable) &&
                !(food is Fruit))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.Quantity * 0.1;
            this.FoodEaten += food.Quantity;
        }
    }
}
