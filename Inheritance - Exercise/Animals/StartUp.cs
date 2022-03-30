using System;
using System.Collections.Generic;

namespace Animals 
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<Animal> animals = new List<Animal>();
            while ((command = Console.ReadLine()) != "Beast!")
            {
                string animalType = command;
                try
                {
                    string[] animalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    switch (animalType)
                    {
                        case "Cat":
                            Cat cat = new Cat(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                            animals.Add(cat);
                            break;
                        case "Dog":
                            Dog dog = new Dog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                            animals.Add(dog);
                            break;
                        case "Frog":
                            Frog frog = new Frog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                            animals.Add(frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(animalInfo[0], int.Parse(animalInfo[1]));
                            animals.Add(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(animalInfo[0], int.Parse(animalInfo[1]));
                            animals.Add(tomcat);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }


                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }

        }
    }
}
