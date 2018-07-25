using Employees.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Commands
{
    public class SetBirthdayCommand : ICommand
    {
        private EmployeeService service;

        public SetBirthdayCommand(EmployeeService service)
        {
            this.service = service;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);
            DateTime date = DateTime.ParseExact(args[1], "dd-MM-yyyy", null);

            var employee = service.SetBirthday(id, date);

            return $"{employee.FirstName} {employee.LastName} birthday set to {args[1]}";

        }
    }
}
