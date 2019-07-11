using System;
using System.Collections.Generic;
using System.Text;

class Person
{
    private List<string> productsList;

    public List<string> ProductsList
    {
        get { return productsList; }
        set { productsList = value; }
    }

    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (value == null || value == "" || value == " ")
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    private double money;

    public double Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    public Person(string name, double money)
    {
        this.Name = name;
        this.Money = money;
        this.ProductsList = new List<string>();
    }

}

