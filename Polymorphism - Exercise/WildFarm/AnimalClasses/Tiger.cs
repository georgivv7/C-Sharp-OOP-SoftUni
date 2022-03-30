using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.FoodClasses;

namespace WildFarm.AnimalClasses
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion,string breed)
            :base(name,weight,livingRegion,breed)
        {

        }

        public override void GetSound()
        {
            Console.WriteLine("ROAR!!!");
        }
        public override void Eat(Food food)
        {
            if (!(food is Meat))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.Quantity * 1.0;
            this.FoodEaten += food.Quantity;
        }
    }
}
