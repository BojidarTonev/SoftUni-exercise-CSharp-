using Employees.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.ModelsDto
{
    public class ManagerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public int CountOfEmployees { get; set; }

    }
}
