using System;
using System.Collections.Generic;
using System.Text;


class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    protected double weightIncrease = 0.40;

    public override void ProduceSound()
    {
        Console.WriteLine("Woof!");
    }
}

