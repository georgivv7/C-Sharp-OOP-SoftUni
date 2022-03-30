using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private int weight;
        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public string Type
        {
            get { return this.type; }
            private set
            {
                if (value == "meat" || value == "veggies" || value == "cheese" || value == "sauce"||
                    value == "Meat" || value == "Veggies" || value == "Cheese" || value == "Sauce")
                {
                    this.type = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }             
            }
        }
        public int Weight
        {
            get { return this.weight; }
            private set
            {
                if (value >= 1 && value <= 50)
                {
                    this.weight = value;                   
                }
                else
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }              
            }
        }
        public double CalculateCalories()
        {
            double calories = 2 * this.weight;
            switch (this.Type.ToLower())
            {
                case"meat":
                    calories *= 1.2;
                    break;
                case "veggies":
                    calories *= 0.8;
                    break;
                case "cheese":
                    calories *= 1.1;
                    break;
                case "sauce":
                    calories *= 0.9;
                    break;
            }
            return calories;
        }
    }
}

