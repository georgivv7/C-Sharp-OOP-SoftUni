using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string pizzaName = string.Empty;
                if (info.Length > 1)
                {
                   pizzaName = info[1];
                }
                
                string[] doughInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string flourType = doughInfo[1].ToLower();
                string bakingTechnique = doughInfo[2].ToLower();
                int weight = int.Parse(doughInfo[3]);
                Dough dough = new Dough(flourType, bakingTechnique, weight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string command = string.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string type = toppingInfo[1];
                    weight = int.Parse(toppingInfo[2]);
                    Topping topping = new Topping(type, weight);
                    pizza.AddTopping(topping);
                }
                var totalCalories = pizza.GetTotalCalories();
                Console.WriteLine($"{pizza.Name} - {totalCalories:F2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
