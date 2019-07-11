using System;
using System.Collections.Generic;
using System.Text;


class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    protected double weightIncrease = 0.10;

    public override void ProduceSound()
    {
        Console.WriteLine("Squeak");
    }

}

