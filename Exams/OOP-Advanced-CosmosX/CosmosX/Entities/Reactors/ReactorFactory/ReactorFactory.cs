namespace CosmosX.Entities.Reactors.ReactorFactory
{
    using CosmosX.Entities.Containers.Contracts;
    using CosmosX.Entities.Reactors.Contracts;
    using CosmosX.Entities.Reactors.ReactorFactory.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ReactorFactory : IReactorFactory
    {
        public IReactor CreateReactor(string reactorTypeName, int id, IContainer moduleContainer, 
            int additionalParameter)
        {
            var assembly = Assembly.GetCallingAssembly();
            var type = assembly.GetTypes()
                .FirstOrDefault(t => t.Name == reactorTypeName + "Reactor");

            IReactor reactor = (IReactor)Activator.CreateInstance(type, id, moduleContainer, 
                additionalParameter);

            return reactor;
        }
    }
}
