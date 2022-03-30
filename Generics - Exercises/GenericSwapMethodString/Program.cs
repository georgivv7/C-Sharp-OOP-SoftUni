using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
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

            var arguments = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstIndex = arguments[0];
            int secondIndex = arguments[1];

            SwapStrings(boxes, firstIndex, secondIndex);

            boxes.ForEach(b => Console.WriteLine(b));
            
        }
        static void SwapStrings<T>(IList<Box<T>> elements, int firstIndex, int secondIndex)
        {
            var firstElement = elements[firstIndex];
            var secondElement = elements[secondIndex];

            elements[firstIndex] = secondElement;
            elements[secondIndex] = firstElement;
        }
    }
}
