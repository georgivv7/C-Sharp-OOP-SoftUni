using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int x = dimensions[0];
            int y = dimensions[1];

            int[,] matrix = new int[x, y];
            ReadMatrix(x, y, matrix);

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoS = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int xI = ivoS[0];
                int yI = ivoS[1];
                int[] evil = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int xE = evil[0];
                int yE = evil[1];

                EvilMovement(matrix, xE, yE);
                IvoMoves(matrix, sum, xI, yI);
                sum = IvoMoves(matrix, sum, xI, yI);
                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static long IvoMoves(int[,] matrix, long sum, int xI, int yI)
        {
            while (xI >= 0 && yI < matrix.GetLength(1))
            {
                if (xI >= 0 && xI < matrix.GetLength(0) && yI >= 0 && yI < matrix.GetLength(1))
                {
                    sum += matrix[xI, yI];
                }

                yI++;
                xI--;
            }
            return sum;            
        }

        private static void EvilMovement(int[,] matrix, int xE, int yE)
        {
            while (xE >= 0 && yE >= 0)
            {
                if (xE >= 0 && xE < matrix.GetLength(0) && yE >= 0 && yE < matrix.GetLength(1))
                {
                    matrix[xE, yE] = 0;
                }
                xE--;
                yE--;
            }

        }

        private static void ReadMatrix(int x, int y, int[,] matrix)
        {
            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }
    }
}
