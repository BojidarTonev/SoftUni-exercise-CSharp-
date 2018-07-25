using Employees.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Commands
{
    public class AddEmployeeCommand : ICommand
    {
        private EmployeeService service;

        public AddEmployeeCommand(EmployeeService service)
        {
            this.service = service;
        }

        public string Execute(params string[] args)
        {
            string firstname = args[0];
            string lastname = args[1];
            decimal salary = decimal.Parse(args[2]);

            service.Add(firstname, lastname, salary);
            return $"{firstname} {lastname} added succesfully!";
        }
    }
}
