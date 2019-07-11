using System;
using System.Collections.Generic;
using System.Text;


class Cram : Food
{
    public Cram(string name)
        : base(name)
    {
        base.happinessPoints = 2;
    }
}

