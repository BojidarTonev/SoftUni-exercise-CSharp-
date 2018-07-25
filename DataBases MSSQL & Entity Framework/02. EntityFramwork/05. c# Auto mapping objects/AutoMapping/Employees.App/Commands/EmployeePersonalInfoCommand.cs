using Employees.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Commands
{
    public class EmployeePersonalInfoCommand : ICommand
    {
        private EmployeeService service;
        public EmployeePersonalInfoCommand(EmployeeService service)
        {
            this.service = service;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);

            var employee = service.PersonalInfo(id);
            return $"ID: {employee.Id} - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}\nBirthday: {employee.birthDate}\nAddress: {employee.Address}";
        }
    }
}
