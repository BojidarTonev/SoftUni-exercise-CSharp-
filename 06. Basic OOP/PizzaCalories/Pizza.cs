using System;
using System.Collections.Generic;
using System.Text;

class Pizza
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15 )
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    private List<Topping> toppings= new List<Topping>();  

    private Dough dough;

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    private double CalculatingTotalCalories()
    {
        double result = 0;
        foreach (var topping in toppings)
        {
            result += topping.GetCalories;
        }

        result += dough.GetCalories;
        return result;
    }

    public double GetCalories
    {
        get
        {
            return this.CalculatingTotalCalories();
        }
    }

    public void AddTopping(Topping topping)
    {
        if (toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        toppings.Add(topping);
    }

    public Pizza(string name)
    {
        Name = name;
        
    }
}

