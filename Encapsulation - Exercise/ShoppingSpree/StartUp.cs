using System;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] personInput = Console.ReadLine().Split(';', '=');
                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();
                for (int i = 0; i < personInput.Length - 1; i += 2)
                {
                    Person person = new Person(personInput[i], decimal.Parse(personInput[i + 1]));
                    people.Add(person);
                }
                string[] productInput = Console.ReadLine().Split(';', '=');
                for (int i = 0; i < productInput.Length - 1; i += 2)
                {
                    Product product = new Product(productInput[i], decimal.Parse(productInput[i + 1]));
                    products.Add(product);
                }

                string command = string.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    var purchaseInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string namePerson = purchaseInfo[0];
                    string nameProduct = purchaseInfo[1];
                    int indexPerson = people.FindIndex(x => x.Name == namePerson);
                    int indexProduct = products.FindIndex(x => x.Name == nameProduct);
                    people[indexPerson].BuyProduct(products[indexProduct].Name, products[indexProduct].Cost);
                }

                foreach (Person person1 in people)
                {
                    if (person1.ProductsBag.Any())
                    {
                        Console.WriteLine($"{person1.Name} - {string.Join(", ", person1.ProductsBag)}");
                    }
                    else
                    {
                        Console.WriteLine($"{person1.Name} - Nothing bought");
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
