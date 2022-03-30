using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            var commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            switch (commands[0])
            {
                case "Push":
                    int[] elements = commands.Skip(1)
                        .Select(x => x.Split(',').First())
                        .Select(int.Parse)
                        .ToArray();
                    stack.Push(elements);
                    break;
                case "Pop":
                    try
                    {
                        stack.Pop();
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
            }
        }

        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
    }
}
