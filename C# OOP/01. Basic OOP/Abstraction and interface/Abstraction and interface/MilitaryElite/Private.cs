using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElitee;


public class Private : IPrivate
{
    public string id { get; }
    public string firstName { get; }
    public string lastName { get; }
    public double salary { get; }

    public Private(string id, string firstName, string lastName, double salary)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.salary = salary;
    }

    public override string ToString()
    {
        return $"Name: {this.firstName} {this.lastName} Id: {this.id} Salary: {this.salary:f2} ";
    }
}

