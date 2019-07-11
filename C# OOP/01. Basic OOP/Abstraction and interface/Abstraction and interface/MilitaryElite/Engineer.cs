using System;
using System.Collections.Generic;
using System.Text;


class Engineer : IEngineer
{
    public string id { get; }
    public string firstName { get; }
    public string lastName { get; }
    public double salary { get; }
    public string corpse { get; }
    public List<Repair> toolKit { get; }

    public Engineer(string id, string firstName, string lastName, double salary, string corpse)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.salary = salary;
        this.corpse = corpse;
        this.toolKit = new List<Repair>();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Name: {this.firstName} {this.lastName} Id: {this.id} Salary: {this.salary:f2}");
        sb.AppendLine($"Corps: {this.corpse}");
        sb.AppendLine("Repairs:");
        sb.AppendLine($"  {string.Join(Environment.NewLine + "  ", this.toolKit)}");

        return sb.ToString().Trim();
    }
}

