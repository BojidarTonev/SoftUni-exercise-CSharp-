using System;
using AutoMapper;
using Employees.App;
using Employees.Data;
using Employees.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace AutoMapping
{
    class Startup
    {
       
        static void Main(string[] args)
        {
            var serviceProvicer = ConfigureServices();

            var engine = new Engine(serviceProvicer);

            engine.Run();
        }

        static IServiceProvider ConfigureServices()
        {
            Mapper.Initialize(x => x.AddProfile<EmployeeProfile>());
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<EmployeesContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddTransient<DatabaseInitializerService>();
            serviceCollection.AddTransient<EmployeeService>();

            //serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<EmployeeProfile>());

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
