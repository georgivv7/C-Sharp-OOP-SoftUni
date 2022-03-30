using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.AnimalClasses
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override void GetSound()
        {
            Console.WriteLine("Cluck");
        }

        public override void Eat(Food food)
        {
            this.Weight += food.Quantity * 0.35;
            this.FoodEaten += food.Quantity;
        }
    }
}
