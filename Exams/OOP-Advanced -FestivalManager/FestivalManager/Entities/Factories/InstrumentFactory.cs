namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
			Assembly assembly = Assembly.GetCallingAssembly();
			var classType = assembly.GetTypes().FirstOrDefault(t => t.Name == type);

			IInstrument instrument = (IInstrument)Activator.CreateInstance(classType);
			return instrument;
		}
	}
}