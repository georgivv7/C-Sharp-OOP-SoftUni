﻿namespace CosmosX.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using CosmosX.Core.Contracts;
    public class CommandParser : ICommandParser
    {
        private const string CommandNameSuffix = "Command";
        private readonly IManager reactorManager;

        public CommandParser(IManager reactorManager)
        {
            this.reactorManager = reactorManager;
        }

        public string Parse(IList<string> arguments)
        {
            string command = arguments[0] + CommandNameSuffix;

            string[] commandArguments = arguments.Skip(1).ToArray();           

            var function = this.reactorManager
                .GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

            string result = (string)function
                .Invoke(this.reactorManager, new object[] { commandArguments });

            return result;

        }
    }
}