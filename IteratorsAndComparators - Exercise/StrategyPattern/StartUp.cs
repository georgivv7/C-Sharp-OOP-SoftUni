using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class StartUp   
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<Person> sortedName = new SortedSet<Person>(new PersonNameComparer());
            SortedSet<Person> sortedAge = new SortedSet<Person>(new PersonAgeComparer());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                Person person = new Person(name, age);

                sortedName.Add(person);
                sortedAge.Add(person);
            }

            Console.WriteLine(string.Join(Environment.NewLine,sortedName));
            Console.WriteLine(string.Join(Environment.NewLine,sortedAge));
        }
    }
}
