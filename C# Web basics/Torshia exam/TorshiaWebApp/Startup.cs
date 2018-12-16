using SIS.MvcFramework;
using SIS.MvcFramework.Logger;
using SIS.MvcFramework.Services;
using TorshiaWebApp.Services;
using TorshiaWebApp.Services.Contracts;

namespace TorshiaWebApp
{
    public class Startup : IMvcApplication
    {
        public MvcFrameworkSettings Configure()
        {
            return new MvcFrameworkSettings();
        }

        public void ConfigureServices(IServiceCollection collection)
        {
            collection.AddService<ILogger, ConsoleLogger>();
            collection.AddService<ITasksService, TasksService>();
            collection.AddService<IReportsService, ReportsService>();
        }
    }
}
