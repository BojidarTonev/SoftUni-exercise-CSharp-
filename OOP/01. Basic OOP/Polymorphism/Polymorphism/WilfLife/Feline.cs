using System;
using System.Collections.Generic;
using System.Text;


public abstract class Feline : Mammal
{
    private string breed;

    protected Feline(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion)
    {
        this.breed = breed;
    }

    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

