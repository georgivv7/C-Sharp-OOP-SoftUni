using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        public string FlourType 
        {
            get { return this.flourType; }
            private set
            {
                if (value == "white"||value=="wholegrain")
                {
                    this.flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public string BakingTechnique 
        {
            get { return this.bakingTechnique; }
            private set
            {
                if (value == "crispy" || value == "chewy" || value == "homemade")
                {
                    this.bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public int Weight 
        {
            get { return this.weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");                  
                }
                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double calories = 2*this.Weight;
            switch (this.FlourType)
            {
                case "white":
                    calories *= 1.5;
                    break;
                case "wholegrain":
                    calories *= 1.0;
                    break;
            }
            switch (this.BakingTechnique)
            {
                case"crispy":
                    calories *= 0.9;
                    break;
                case "chewy":
                    calories *= 1.1;
                    break;
                case "homemade":
                    calories *= 1.0;
                    break;
            }
            return calories;
        }
    }
}
