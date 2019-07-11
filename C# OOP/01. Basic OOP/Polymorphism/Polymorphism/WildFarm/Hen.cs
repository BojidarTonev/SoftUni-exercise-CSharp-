using System;
using System.Collections.Generic;
using System.Text;


class Hen : Bird
{
    public Hen(string name, double weight, int foodEaten, double wingSize)
        : base(name, weight, foodEaten, wingSize)
    {
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Cluck");
    }
}

