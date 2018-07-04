using System;
using System.Collections.Generic;
using System.Text;


class Mushrooms : Food
{
    public Mushrooms(string name)
        : base(name)
    {
        base.happinessPoints = -10;
    }
}

