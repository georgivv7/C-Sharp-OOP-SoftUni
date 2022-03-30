using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.FoodClasses;

namespace WildFarm.AnimalClasses
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            :base(name,weight,wingSize)
        {
                
        }

        public override void GetSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
        public override void Eat(Food food)
        {
            if (!(food is Meat))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.Quantity * 0.25;
            this.FoodEaten += food.Quantity;
        }
    }
}
