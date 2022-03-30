using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<string> productsBag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.ProductsBag = new List<string>();
        }
        public string Name 
        {
            get { return this.name; }
            private set
            {
                if (value == string.Empty || value == null || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money 
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }            
        }
        public List<string> ProductsBag 
        { 
            get { return this.productsBag; } 
            set { this.productsBag = value; } 
        }

        public void BuyProduct(string productName, decimal productPrice)
        {
            if (productPrice > this.Money)
            {
                Console.WriteLine($"{this.Name} can't afford {productName}");
            }
            else
            {
                this.Money -= productPrice;
                this.ProductsBag.Add(productName);
                Console.WriteLine($"{this.Name} bought {productName}");
            }
        }

    }
}
