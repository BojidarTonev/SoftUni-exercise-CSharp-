using Employees.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Commands
{
    public class EmployeeInfoCommand : ICommand
    {
        private EmployeeService service;
        public EmployeeInfoCommand(EmployeeService service)
        {
            this.service = service;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);
            var employee = service.EmployeeInfo(id);

            return $"ID: {employee.Id} - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}";
        }
    }
}
