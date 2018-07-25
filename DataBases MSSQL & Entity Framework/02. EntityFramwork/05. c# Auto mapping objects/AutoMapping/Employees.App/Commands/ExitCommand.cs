using Employees.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Commands
{
    public class ExitCommand : ICommand
    {
        private EmployeeService service;
        public ExitCommand(EmployeeService service)
        {
            this.service = service;
        }

        public string Execute(params string[] args)
        {
            Console.WriteLine("Bye-bye!");
            Environment.Exit(0);
            return "";
        }
    }
}
