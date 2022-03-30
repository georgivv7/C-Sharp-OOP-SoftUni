using System;
using System.Collections.Generic;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input.Length == 4)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    citizen.BuyFood();
                    citizens.Add(citizen);
                }
                else
                {
                    Rebel rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    rebel.BuyFood();
                    rebels.Add(rebel);
                }
            }
            string command = string.Empty;
            int totalAmountFood = 0;
            while ((command = Console.ReadLine())!= "End")
            {
                string name = command;
                foreach (Rebel rebel in rebels)
                {
                    if (name == rebel.Name)
                    {
                        totalAmountFood += rebel.Food;
                    }
                }
                foreach (Citizen citizen in citizens)
                {
                    if (name == citizen.Name)
                    {
                        totalAmountFood += citizen.Food;
                    }
                }
            }
            Console.WriteLine(totalAmountFood);
        }
    }
}
