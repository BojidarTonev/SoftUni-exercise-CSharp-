using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;
    private int id;

    public Person(string name, int id)
    {
        this.Name = name;
        this.Id = id;
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}

