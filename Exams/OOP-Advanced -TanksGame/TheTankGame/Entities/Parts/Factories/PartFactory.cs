namespace TheTankGame.Entities.Parts.Factories  
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Parts.Factories.Contracts;

    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            var assembly = Assembly.GetCallingAssembly();
            var type = assembly.GetTypes()
                .FirstOrDefault(t => t.Name == partType + "Part");

            IPart part = (IPart)Activator.CreateInstance(type, model, weight, 
                price, additionalParameter);

            return part;
        }
    }
}
