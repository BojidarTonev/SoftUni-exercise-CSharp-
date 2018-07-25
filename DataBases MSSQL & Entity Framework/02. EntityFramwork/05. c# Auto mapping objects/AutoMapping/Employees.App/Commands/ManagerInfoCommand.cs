using Employees.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Commands
{
    public class ManagerInfoCommand : ICommand
    {
        private readonly EmployeeService service;
        public ManagerInfoCommand(EmployeeService service)
        {
            this.service = service;
        }

        public string Execute(params string[] args)
        {
            int managerId = int.Parse(args[0]);

            var manager = service.ManagerInfo(managerId);

            var sb = new StringBuilder();

            sb.AppendLine($"{manager.FirstName} {manager.LastName} | Employees: {manager.Employees.Count}");
            if (manager.Employees.Count == 0)
            {
                sb.AppendLine("[no one here]");
            }
            else
            {
                foreach (var e in manager.Employees)
                {
                    sb.AppendLine($"\t- {e.FirstName} {e.LastName} - ${e.Salary:f2}");
                }
            }

            return sb.ToString();
        }
    }
}
