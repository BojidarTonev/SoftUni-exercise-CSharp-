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
		    Type typeOfInstrument = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name.Equals(type));

		    IInstrument instance = (IInstrument)Activator.CreateInstance(typeOfInstrument);

		    return instance;
        }
	}
}