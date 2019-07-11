using System;
using System.Collections.Generic;
using System.Text;


class Citizen : IResident, IPerson
{
    public string country { get; }
    public string name { get; }
    public int age { get; }

    public Citizen(string name, string country, int age)
    {
        this.name = name;
        this.country = country;
        this.age = age;
    }

    string IPerson.GetName()
    {
        return $"{this.name}";
    }

    string IResident.GetName()
    {
        return $"Mr/Ms/Mrs {this.name}";
    }
}

