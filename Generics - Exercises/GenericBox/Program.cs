using System;

namespace GenericBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            var @string = Console.ReadLine();
            Box<string> box = new Box<string>(@string);
            Console.WriteLine(box);
        }
    }
}
