using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;
    using System.Reflection;
    using System.Linq;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);
            if (model == null)
            {
                throw new ArgumentException("Invalid Unit Type!");
            }

            if (!model.GetInterfaces().Any(i => i == typeof(IUnit)))
            {
                throw new ArgumentException($"{unitType} is Not a Unit Type!");
            }

            IUnit unit = (IUnit)Activator.CreateInstance(model);
            return unit;
        }
    }
}
