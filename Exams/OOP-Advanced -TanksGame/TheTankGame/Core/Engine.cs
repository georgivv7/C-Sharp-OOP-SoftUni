namespace TheTankGame.Core
{
    using System;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string[] args = reader.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                var message = this.commandInterpreter.ProcessInput(args);
                this.writer.WriteLine(message);

                if (args[0] == "Terminate")
                {
                    break;
                }
            }
            
        }
    }
}