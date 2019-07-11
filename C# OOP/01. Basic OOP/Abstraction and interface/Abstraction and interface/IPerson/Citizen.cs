using System;
using System.Collections.Generic;
using System.Text;



public class Citizen : IPerson
{
    public string name { get; set; }
    public int age { get; set; }

    public Citizen(string name, int age)
    {
        this.age = age;
        this.name = name;
    }

    public override string ToString()
    {
        return $"{this.name}\n{this.age}";
    }
}

