using System;
using System.Collections.Generic;
using System.Text;

class LeutenantGeneral : ILeutenantGeneral
{
    public string id { get; }
    public string firstName { get; }
    public string lastName { get; }
    public double salary { get; }
    public List<Private> peopleUnderCommand { get; }


    public LeutenantGeneral(string id, string firstName, string lastName, double salary)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.salary = salary;
        this.peopleUnderCommand = new List<Private>();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Name: {this.firstName} {this.lastName} Id: {this.id} Salary: {this.salary:f2}");
        sb.AppendLine("Privates:");
        sb.AppendLine($"  {string.Join(Environment.NewLine + "  ", this.peopleUnderCommand)}");

        return sb.ToString().Trim();
    }
}

