namespace Employees.App.Commands
{
    using Employees.Services;
    using System.Linq;

    
    public class SetAddressCommand : ICommand
    {
        private EmployeeService service;

        public SetAddressCommand(EmployeeService service)
        {
            this.service = service;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);
            var tempAddress = args.Skip(1);

            string address = string.Join(" ", tempAddress);

            var employee = service.SetAddress(id, address);
            return $"{employee.FirstName} {employee.LastName} address set to {address}";
        }
    }
}
