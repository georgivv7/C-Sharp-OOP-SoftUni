using System;
using System.Collections.Generic;

namespace GenericCountMethodDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<double>> boxes = new List<Box<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                Box<double> box = new Box<double>(input);
                boxes.Add(box);
            }
            double element = double.Parse(Console.ReadLine());

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
