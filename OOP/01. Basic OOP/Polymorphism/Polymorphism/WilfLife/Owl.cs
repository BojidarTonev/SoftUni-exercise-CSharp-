using System;
using System.Collections.Generic;
using System.Text;


class Owl:Bird
{
    public Owl(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    protected double weightIncrease = 0.25;

    public override void ProduceSound()
    {
        Console.WriteLine("Hoot Hoot");
    }
}

