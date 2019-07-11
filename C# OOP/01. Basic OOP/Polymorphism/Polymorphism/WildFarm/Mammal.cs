using System;
using System.Collections.Generic;
using System.Text;


class Mammal:Animal
{
    private string livingRegion;

    public Mammal(string name, double weight, int foodEaten, string livingRegion) 
        : base(name, weight, foodEaten)
    {
        this.livingRegion = livingRegion;
    }

    public string LivingRegion
    {
        get { return livingRegion; }
        set { livingRegion = value; }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

