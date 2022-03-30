using System;
using System.Collections.Generic;
using WildFarm.AnimalClasses;
using WildFarm.FoodClasses;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string animalType = string.Empty;
            int count = 0;
            List<Animal> animals = new List<Animal>();
            List<Food> foods = new List<Food>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                Animal animal = null;
                Food food = null;

                if (count % 2 == 0)
                {
                    string[] animalInput = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    count++;
                    animalType = animalInput[0];
                    string name = animalInput[1];
                    double weight = double.Parse(animalInput[2]);
                    switch (animalType)
                    {
                        case "Hen":
                            double wingSize = double.Parse(animalInput[3]);
                            animal = new Hen(name, weight, wingSize);
                            break;
                        case "Owl":
                            wingSize = double.Parse(animalInput[3]);
                            animal = new Owl(name, weight, wingSize);
                            break;
                        case "Mouse":
                            string livingRegion = animalInput[3];
                            animal = new Mouse(name, weight, livingRegion);
                            break;
                        case "Dog":
                            livingRegion = animalInput[3];
                            animal = new Dog(name, weight, livingRegion);
                            break;
                        case "Cat":
                            livingRegion = animalInput[3];
                            string breed = animalInput[4];
                            animal = new Cat(name, weight, livingRegion, breed);
                            break;
                        case "Tiger":
                            livingRegion = animalInput[3];
                            breed = animalInput[4];
                            animal = new Tiger(name, weight, livingRegion, breed);
                            break;
                    }
                    animals.Add(animal);
                }
                else
                {
                    string[] foodInput = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    count++;
                    string foodType = foodInput[0];
                    int quantity = int.Parse(foodInput[1]);
                    switch (foodType)
                    {
                        case "Vegetable":
                            food = new Vegetable(quantity);
                            break;
                        case "Fruit":
                            food = new Fruit(quantity);
                            break;
                        case "Meat":
                            food = new Meat(quantity);
                            break;
                        case "Seeds":
                            food = new Seeds(quantity);
                            break;
                    }
                    foods.Add(food);
                }
            }

            for (int i = 0; i < animals.Count; i++)
            {
                try
                {
                    animals[i].GetSound();
                    animals[i].Eat(foods[i]);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
          
