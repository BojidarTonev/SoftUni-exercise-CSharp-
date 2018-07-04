using System;
using System.Collections.Generic;
using System.Text;


class Feline : Mammal
{
    private string breed;

    public Feline(string name, double weight, int foodEaten, string livingRegion, string breed) 
        : base(name, weight, foodEaten, livingRegion)
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

