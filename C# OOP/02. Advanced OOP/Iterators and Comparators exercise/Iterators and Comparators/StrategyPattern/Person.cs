using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;
    private int age;

    public Person(string Name, int Age)
    {
        this.Name = Name;
        this.Age = Age;
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public override string ToString()
    {
        return $"{this.name} {this.age}";
    }
}

