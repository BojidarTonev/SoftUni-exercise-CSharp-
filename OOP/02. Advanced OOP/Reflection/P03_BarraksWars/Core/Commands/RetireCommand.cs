using System;
using System.Reflection;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory factory) 
            : base(data, repository, factory)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];
            try
            {   
                this.Repository.RemoveUnit(unitType);
                return $"{unitType} retired!";
            }
            catch (Exception e)
            {
                throw new ArgumentException("No such units in repository.", e);
            }
        }
    }
}
