using System;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    public class FightCommand : Command
    {
        public FightCommand(string[] data, IRepository repository, IUnitFactory factory) 
            : base(data, repository, factory)
        {
        }

        public override string Execute()
        {           
            Environment.Exit(0);
            return null;
        }
    }
}
