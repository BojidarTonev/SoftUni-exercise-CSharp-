using System;
using System.Collections.Generic;
using System.Text;


class Melon : Food
{
    public Melon(string name)
        : base(name)
    {
        base.happinessPoints = 1;
    }
}

