using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    public class ReportCommand : Command
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory factory) 
            : base(data, repository, factory)
        {
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
