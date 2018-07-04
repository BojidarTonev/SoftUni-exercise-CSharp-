using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;


class Apple : Food
{
    public Apple(string name)
    :base(name)
    {
        base.happinessPoints = 1;
    }
}

