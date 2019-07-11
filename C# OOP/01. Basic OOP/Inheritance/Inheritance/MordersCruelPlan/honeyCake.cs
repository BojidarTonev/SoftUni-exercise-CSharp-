using System;
using System.Collections.Generic;
using System.Text;


class honeyCake : Food
{
    public honeyCake(string name)
        : base(name)
    {
        base.happinessPoints = 5;
    }
}

