namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities;
    using System.IO;
    using FestivalManager.Core.IO;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IWriter writer, IReader reader,
            IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }
        public void Run()
        {
            string input = null;
            while ((input = reader.ReadLine()) != "END")
            {
                try
                {
                    var message = this.ProcessCommand(input);
                    writer.WriteLine(message);
                }
                catch (Exception ex)
                {
                    writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            string report = this.festivalCоntroller.ProduceReport();
            writer.WriteLine(report);
        }
        public string ProcessCommand(string input)
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var command = tokens[0];
            var parameters = tokens.Skip(1).ToArray();

            if (command == "LetsRock")
            {
                var sets = this.setCоntroller.PerformSets();
                return sets;
            }

            var festivalcontrolfunction = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

            string message;

            try
            {
                message = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller,
                    new object[] { parameters });
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }

            return message;
        }
    }
}