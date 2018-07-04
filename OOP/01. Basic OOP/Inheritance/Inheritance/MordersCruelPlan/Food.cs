using System;
using System.Collections.Generic;
using System.Text;


abstract class Food
{
    public string name;
    public int happinessPoints;

    protected Food(string name)
    {
        this.name = name;
    }
}

