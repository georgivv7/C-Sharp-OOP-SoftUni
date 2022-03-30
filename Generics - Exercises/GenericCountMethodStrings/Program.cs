using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Box<string> box = new Box<string>(input);
                boxes.Add(box);
            }
            string element = Console.ReadLine();

            Console.WriteLine(CountGreater(boxes, element));         
        }

        static int CountGreater<T>(IEnumerable<Box<T>> boxess, T element)
            where T : IComparable<T>
        {
            int counter = 0;
            foreach (var item in boxess)
            {
                if (item.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
