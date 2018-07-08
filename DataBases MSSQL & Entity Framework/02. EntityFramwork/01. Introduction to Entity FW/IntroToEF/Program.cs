using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EmployeesFullInformation.Data;
using EmployeesFullInformation.Data.Models;

namespace EmployeesFullInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
        }

        private static void DeleteProjectById(SoftUniContext db)
        {
            var project = db.Projects.First(p => p.ProjectId == 2);

            db.EmployeesProjects.ToList().ForEach(ep => db.EmployeesProjects.Remove(ep));
            db.Projects.Remove(project);

            db.SaveChanges();

            db.Projects.Take(10).Select(p => p.Name).ToList().ForEach(p => Console.WriteLine(p));
        }

        private static void RemoveTowns(SoftUniContext db)
        {
            string townToBeDeletedName = Console.ReadLine();
            List<Address> addressesFromTheTargetTown = db.Addresses
                .Where(a => a.Town.Name.Equals(townToBeDeletedName))
                .ToList();

            foreach (Employee employee in db.Employees)
            {
                if (addressesFromTheTargetTown.Contains(employee.Address))
                {
                    employee.Address = null;
                }
            }

            db.Addresses.RemoveRange(addressesFromTheTargetTown);
            Town townToBeDeleted = db.Towns.SingleOrDefault(t => t.Name.Equals(townToBeDeletedName));
            db.Towns.Remove(townToBeDeleted);
            db.SaveChanges();

            int removedAddressesCount = addressesFromTheTargetTown.Count;
            string addressSingleOrPlural;
            string wasWere;
            if (removedAddressesCount > 1)
            {
                addressSingleOrPlural = "addresses";
                wasWere = "were";
            }
            else
            {
                addressSingleOrPlural = "address";
                wasWere = "was";
            }

            Console.WriteLine($"{removedAddressesCount} {addressSingleOrPlural} in {townToBeDeletedName} {wasWere} deleted");
        }

        private static void FindEmployeesByFirstNameStartingWithSa(SoftUniContext db)
        {
            var searchedEmployees = db.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            foreach (var emp in searchedEmployees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:F2})");
            }
        }

        private static void IncreaseSalaries(SoftUniContext db)
        {
            string[] targetedDepartments = { "Engineering", "Tool Design", "Marketing", "Information Services" };

            List<Employee> targetedEmployees = db.Employees
                .Where(e => targetedDepartments.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (Employee emp in targetedEmployees)
            {
                emp.Salary *= 1.12m;
                Console.WriteLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F2})");
            }

            //db.SaveChanges();
        }

        private static void FindLatest10Projects(SoftUniContext db)
        {
            var latestTenProjects = db.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .ToList();

            foreach (var project in latestTenProjects)
            {
                Console.WriteLine(project.Name);
                Console.WriteLine(project.Description);
                Console.WriteLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }
        }

        private static void DepartmentsWithMoreThan5Employees(SoftUniContext db)
        {
            var selectedDepartments = db.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    d.Manager,
                    d.Employees
                })
                .ToList();

            foreach (var department in selectedDepartments)
            {
                Console.WriteLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");

                foreach (Employee emp in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }

                Console.WriteLine(new string('-', 10));
            }
        }

        private static void Employee147(SoftUniContext db)
        {
            const int SearchedEmployeeId = 147;

            var searchedEmployee = db.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(ep => new
                    {
                        ep.Project.Name
                    })
                })
                .SingleOrDefault(e => e.EmployeeId == SearchedEmployeeId);

            if (searchedEmployee != null)
            {
                Console.WriteLine($"{searchedEmployee.FirstName} {searchedEmployee.LastName} - {searchedEmployee.JobTitle}");

                foreach (var project in searchedEmployee.Projects.OrderBy(ep => ep.Name))
                {
                    Console.WriteLine($"{project.Name}");
                }
            }
            else
            {
                Console.WriteLine($"Employee with ID {SearchedEmployeeId} was not found.");
            }
        }

        private static void AddressesByTown(SoftUniContext db)
        {
            var selectedAddresses = db.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    Text = a.AddressText,
                    Town = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .ToList();

            foreach (var address in selectedAddresses)
            {
                Console.WriteLine($"{address.Text}, {address.Town} - {address.EmployeesCount} employees");
            }
        }

        private static void EmployeesAndProjects(SoftUniContext db)
        {
            var selectedEmployees = db.Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ep.Project.Name,
                            ep.Project.StartDate,
                            ep.Project.EndDate
                        })
                })
                .Take(30)
                .ToList();

            foreach (var e in selectedEmployees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.Projects)
                {
                    string projectName = p.Name;
                    string startDate = p.StartDate.ToString(CultureInfo.InvariantCulture);
                    string endDate;

                    if (p.EndDate != null)
                    {
                        endDate = p.EndDate.Value.ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        endDate = "not finished";
                    }

                    Console.WriteLine($"--{projectName} - {startDate} - {endDate}");
                }
            }
        }

        private static void AddingNewAddressAndUpdatingEmployees(SoftUniContext db)
        {
            Address adres = new Address() { TownId = 4, AddressText = "Vitoshka 15" };

            db.Employees.Single(e => e.LastName == "Nakov").Address = adres;

            db.SaveChanges();

            var employees = db.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => new { e.Address.AddressText });

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.AddressText}");
            }
        }

        private static void EmployeesFromResearchAndDevelopment(SoftUniContext db)
        {

            var employees = db.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DeptName = e.Department.Name,
                    Salary = e.Salary
                });


            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} from {e.DeptName} - ${e.Salary:f2}");
            }
        }

        private static void EmployeesWithSalaryOver50000(SoftUniContext db)
        {
            using (db)
            {
                var employees = db.Employees
                    .Where(e => e.Salary > 50000)
                    .OrderBy(e => e.FirstName)
                    .Select(e => new { Name = e.FirstName });

                foreach (var e in employees)
                {
                    Console.WriteLine(e.Name);
                }
            }
        }

        private static void EmployeesFullInformation(SoftUniContext db)
        {
            using (db)
            {
                var employees = db.Employees.ToList().OrderBy(e => e.EmployeeId);

                foreach (var e in employees)
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
                }
            }
        }
    }
}

