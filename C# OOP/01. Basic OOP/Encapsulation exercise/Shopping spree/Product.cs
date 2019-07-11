using System;
using System.Collections.Generic;
using System.Text;


class Product
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private double cost;

    public double Cost
    {
        get { return cost; }
        set { cost = value; }
    }

    public Product(string name, double cost)
    {
        this.Name = name;
        this.Cost = cost;
    }
}

