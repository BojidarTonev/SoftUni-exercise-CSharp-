using System;
using System.Collections.Generic;
using System.Text;

class Food
{
    private int quantity;
    private string type;

    public Food(string type, int qantity)
    {
        this.Quantity = qantity;
        this.Type = type;
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
