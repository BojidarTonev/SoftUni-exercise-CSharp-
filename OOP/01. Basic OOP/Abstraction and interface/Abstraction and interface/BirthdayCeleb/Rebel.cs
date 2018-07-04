using System;
using System.Collections.Generic;
using System.Text;


class Rebel : IBuyer
{
    public int food { get; }
    public int age { get; }
    public string name { get; }
    private string gangName;

    public string GangName
    {
        get { return gangName; }
        set { gangName = value; }
    }

    public int BuyFood()
    {
        return 5;
    }

    public Rebel(string name, int age, string gangName)
    {
        this.food = 0;
        this.name = name;
        this.age = age;
        this.GangName = gangName;
    }
}

