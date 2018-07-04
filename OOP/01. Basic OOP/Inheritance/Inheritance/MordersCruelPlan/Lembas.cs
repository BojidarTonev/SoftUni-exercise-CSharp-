using System;
using System.Collections.Generic;
using System.Text;


class Lembas : Food
{
    public Lembas(string name)
        : base(name)
    {
        base.happinessPoints = 3;
    }
}

