using System;
using System.Collections.Generic;
using System.Text;


class Bird : Animal
{
    private double wingSize;

    public Bird(string name, double weight, int foodEaten, double wingSize) 
        : base(name, weight, foodEaten)
    {
        this.wingSize = wingSize;
    }

    public double WingSize
    {
        get { return wingSize; }
        set { wingSize = value; }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}

