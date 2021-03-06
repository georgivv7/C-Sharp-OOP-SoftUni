using System;

namespace _01._RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int rhombusSize = int.Parse(Console.ReadLine());
            for (int rowSize = 1; rowSize <= rhombusSize; rowSize++)
            {
                PrintRow(rhombusSize, rowSize);
            }
            for (int rowSize = rhombusSize - 1; rowSize >= 1; rowSize--)
            {
                PrintRow(rhombusSize, rowSize);
            }
        }

        private static void PrintRow(int rhombusSize, int rowSize)
        {
            for (int counter = 0; counter < rhombusSize - rowSize; counter++)
            {
                Console.Write(" ");
            }
            for (int counter = 1; counter < rowSize; counter++)
            {
                Console.Write("* ");
            }
            Console.WriteLine("*");
        }
    }
}
