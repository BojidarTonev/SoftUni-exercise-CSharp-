using System;
using System.Collections.Generic;
using System.Text;


class Mouse : Mammal
{
    public Mouse(string name, double weight, int foodEaten, string livingRegion)
        : base(name, weight, foodEaten, livingRegion)
    {
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Squeak");
    }
}

