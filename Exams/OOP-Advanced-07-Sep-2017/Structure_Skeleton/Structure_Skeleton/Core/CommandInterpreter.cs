using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IHarvesterController HarvesterController, 
        IProviderController ProviderController)
    {
        this.HarvesterController = HarvesterController;
        this.ProviderController = ProviderController;
    }
    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public string ProcessCommand(IList<string> args)
    {
        ICommand command = this.CreateCommand(args);

        string result = command.Execute();
        return result;
    }

    private ICommand CreateCommand(IList<string> args)
    {
        string commandName = args[0];

        Type commandType = Assembly.GetCallingAssembly().GetTypes()
            .FirstOrDefault(t => t.Name == commandName + "Command");
        if (commandType == null)
        {
            throw new ArgumentException(string.Format(Constants.CommandNotFound,commandName));
        }

        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new InvalidOperationException(string.Format(Constants.InvalidCommand, commandName));
        }

        ConstructorInfo ctorInfo = commandType.GetConstructors().First();
        ParameterInfo[] parameterInfos = ctorInfo.GetParameters();
        object[] parameters = new object[parameterInfos.Length];

        for (int i = 0; i < parameterInfos.Length; i++)
        {
            Type paramType = parameterInfos[i].ParameterType;

            if (paramType == typeof(IList<string>))
            {
                parameters[i] = args.Skip(1).ToList();
            }
            else
            {
                PropertyInfo param = this.GetType().GetProperties()
                    .FirstOrDefault(p => p.PropertyType == paramType);
                parameters[i] = param.GetValue(this);
            }
        }

        ICommand instance = (ICommand)Activator.CreateInstance(commandType, parameters);
        return instance;
    }
}

