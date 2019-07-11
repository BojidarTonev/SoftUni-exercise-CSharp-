using System;
using System.Collections.Generic;
using System.Text;

class Topping
{
    private string toppingType;

    public string ToppingType
    {
        get { return toppingType; }
        set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            toppingType = value;
        }
    }

    private double grams;

    public double Grams
    {
        get { return grams; }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{toppingType} weight should be in the range [1..50].");
            }
            grams = value;
        }
    }

    private double modifier;

    public Topping(string toppingType, double grams)
    {
        this.ToppingType = toppingType;
        this.Grams = grams;
        if (this.toppingType.ToLower() == "meat")
        {
            modifier = 1.2;
        }

        if (this.toppingType.ToLower() == "veggies")
        {
            modifier = 0.8;
        }

        if (this.toppingType.ToLower() == "cheese")
        {
            modifier = 1.1;
        }

        if (this.toppingType.ToLower() == "sauce")
        {
            modifier = 0.9;
        }
    }

    private double GalculateCalories(double grams, double modifier)
    {
        double result = 2*(this.grams * this.modifier);
        return result;
    }

    public double GetCalories
    {
        get
        {
            return this.GalculateCalories(grams, modifier);
        }
    }
}

