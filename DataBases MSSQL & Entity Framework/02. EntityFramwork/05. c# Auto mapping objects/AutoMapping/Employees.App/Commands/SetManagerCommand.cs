namespace Employees.App.Commands
{
    using Employees.Services;


    class SetManagerCommand : ICommand
    {
        private EmployeeService service;
        public SetManagerCommand(EmployeeService service)
        {
            this.service = service;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

            int managerId = int.Parse(args[1]);

            var employee = service.SetManager(employeeId, managerId);

            return $"{employee.Manager.FirstName} {employee.Manager.LastName} is now manager on {employee.FirstName} {employee.LastName}.";
        }
    }
}
