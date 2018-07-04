using System;
using System.Collections.Generic;
using System.Text;


public abstract class Animal
{
    private string name;
    private double weight;
    private int foodEaten;

    public Animal(string name, double weight, int foodEaten)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = foodEaten;
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        set { foodEaten = value; }
    }

    public double Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public virtual void ProduceSound()
    {

    }

}

