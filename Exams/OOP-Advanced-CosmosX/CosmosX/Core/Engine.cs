namespace CosmosX.Core
{
    using CosmosX.Core.Contracts;
    using CosmosX.IO.Contracts;
    using System;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.isRunning = true;
        }

        public void Run()
        {
            while (isRunning)
            {
                string[] args = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var message = this.commandParser.Parse(args);
                this.writer.WriteLine(message);

                if (args[0] == "Exit")
                {
                    isRunning = false;
                }
            }
        }
    }
}