using System;
using System.Collections.Generic;
using System.Text;


class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    public override void ProduceSound()
    {
        Console.WriteLine("ROAR!!!");
    }
}

