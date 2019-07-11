using System;
using System.Collections.Generic;
using System.Text;


class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    protected double weightIncrease = 0.35;

    public override void ProduceSound()
    {
        Console.WriteLine("Cluck");
    }
}

