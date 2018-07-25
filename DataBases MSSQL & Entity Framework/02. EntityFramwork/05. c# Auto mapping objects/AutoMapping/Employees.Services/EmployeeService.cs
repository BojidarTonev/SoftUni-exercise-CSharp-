using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using Employees.Data;
using Employees.Models;
using Employees.ModelsDto;
using System;

namespace Employees.Services
{
    public class EmployeeService
    {
        private readonly EmployeesContext context;

        public EmployeeService(EmployeesContext context)
        {
            this.context = context;
        }

        private EmployeeDto ById(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                throw new ArgumentException("There is no employee with such Id in the database.");
            }

            var employeeDto = Mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public List<EmployeesOlderThanDto> ListEmployeesOlderThan(string date)
        {
            var employees = context.Employees
                .Where(e => e.Birthday.CompareTo(DateTime.Parse(date)) > 0)
                .ToList();

            var employeeDtos = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeesOlderThanDto>>(employees)
                .OrderByDescending(x => x.Salary)
                .ToList();

            return employeeDtos;              
        }

        public ManagerDto ManagerInfo(int id)
        {
            var manager = context.Employees.Find(id);

            if (manager == null)
            {
                throw new InvalidOperationException("Invalid Id.");
            }

            var managerDto = Mapper.Map<ManagerDto>(manager);

            return managerDto;
        }

        public EmployeeDto SetManager(int employeeId, int managerId)
        {
            var employee = context.Employees.Find(employeeId);
            var manager = context.Employees.Find(managerId);

            employee.Manager = manager;
            employee.ManagerId = managerId;

            manager.Employees.Add(employee);

            context.SaveChanges();

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public void Add(string firstName, string lastName, decimal Salary)
        {
            var employeeDto = new EmployeeDto()
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = Salary
            };

            var employee = Mapper.Map<Employee>(employeeDto);
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public Employee SetBirthday(int id, DateTime date)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                throw new ArgumentException("No employee with such Id exists in the database.");
            }
            employee.Birthday = date;
            context.SaveChanges();

            return employee;
        }

        public Employee SetAddress(int id, string address)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                throw new ArgumentException("There is no employee with such Id in the database.");
            }
            employee.Address = address;
            context.SaveChanges();

            return employee;
        }

        public EmployeeDto EmployeeInfo(int id)
        {
            return ById(id);
        }

        public PersonalInfoDto PersonalInfo(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                throw new ArgumentException("Invalid Employee Id");
            }

            var personalInfo = Mapper.Map<PersonalInfoDto>(employee);
            return personalInfo;
        }

    }
}
