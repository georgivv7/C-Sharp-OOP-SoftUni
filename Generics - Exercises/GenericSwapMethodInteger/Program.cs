using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<int>> boxes = new List<Box<int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
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
