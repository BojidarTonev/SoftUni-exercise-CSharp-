using System;
using System.Collections.Generic;
using System.Text;


class Citizen : IBuyer
{
    public int food { get; }
    public int age { get; }
    public string name { get; }
    private string id;
    private string birthDate;

    public string BirthDate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public int BuyFood()
    {
        return 10;
    }

    public Citizen(string name, int age, string id, string birthDate)
    {
        this.food = 0;
        this.name = name;
        this.age = age;
        this.Id = id;
        this.BirthDate = birthDate;
    }
}

