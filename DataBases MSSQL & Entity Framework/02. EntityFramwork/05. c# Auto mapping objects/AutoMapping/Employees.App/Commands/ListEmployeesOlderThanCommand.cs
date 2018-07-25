using Employees.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Commands
{
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly EmployeeService service;

        public ListEmployeesOlderThanCommand(EmployeeService service)
        {
            this.service = service;
        }

        public string Execute(params string[] args)
        {
            string date = args[0];

            var employees = service.ListEmployeesOlderThan(date);

            var sb = new StringBuilder();
            string manager = "";

            foreach (var e in employees)
            {
                if (e.ManagerLastName == null)
                {
                    manager = "[no manager]";
                }
                else
                {
                    manager = $"{e.ManagerLastName}";
                }
                sb.AppendLine($"{e.FirstName} {e.LastName} - ${e.Salary:f2} - Manager: {manager}");
            }

            return sb.ToString();
        }
    }
}
