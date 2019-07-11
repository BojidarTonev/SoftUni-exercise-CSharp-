using System;
using System.Collections.Generic;
using System.Text;


class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    protected double weightIncrease = 0.30;

    public override void ProduceSound()
    {
        Console.WriteLine("Meow");
    }
}

