namespace HAD.IO
{
    using HAD.Contracts;
    using System;
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}