using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        ListyIterator<string> listyIterator = null;

        string input = string.Empty;

        while ((input = Console.ReadLine())!= "END")
        {
            string[] commands = input.Split();

            switch (commands[0])
            {
                case "Create":
                    listyIterator = new ListyIterator<string>(commands.Skip(1).ToArray());
                    break;
                case "Move":
                    Console.WriteLine(listyIterator.Move());
                    break;
                case "Print":
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "HasNext":
                    Console.WriteLine(listyIterator.HasNext());
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
