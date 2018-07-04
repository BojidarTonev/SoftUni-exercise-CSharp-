using _03BarracksFactory.Contracts;

public abstract class Command : IExecutable
{
    private string[] data;
    private IRepository repository;
    private IUnitFactory unitFactory;

    protected Command(string[] data, IRepository repository, IUnitFactory factory)
    {
        this.Data = data;
        this.Repository = repository;
        this.UnitFactory = factory;
    }

    protected IUnitFactory UnitFactory
    {
        get { return unitFactory; }
        private set { unitFactory = value; }
    }
    
    protected IRepository Repository
    {
        get { return repository; }
        private set { repository = value; }
    }

    protected string[] Data
    {
        get { return data; }
        private set { data = value; }
    }

    public abstract string Execute();
}
