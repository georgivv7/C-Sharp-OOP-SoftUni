using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        public Pizza(string name,Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }
        public int NumOfToppings => this.toppings.Count;
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == string.Empty || value == " "|| value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        
        public Dough Dough
        {
            get
            {
                return this.dough;
            }
            set 
            { 
                this.dough = value; 
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.NumOfToppings < 10)
            {
                this.toppings.Add(topping);
            }
            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            
        }
        public double GetTotalCalories()
        {
            double totalCalories = 0;
            totalCalories += this.dough.CalculateCalories();
            foreach (Topping topping in this.toppings)
            {
                totalCalories += topping.CalculateCalories();
            }
            return totalCalories;
        }
}   }
