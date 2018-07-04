using System;
using System.Collections.Generic;
using System.Text;


public class Food
{
    private int quantity;
    private string type;

    public Food(string type, int quantity)
    {
        this.Type = type;
        this.Quantity = quantity;
    }
    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

}

