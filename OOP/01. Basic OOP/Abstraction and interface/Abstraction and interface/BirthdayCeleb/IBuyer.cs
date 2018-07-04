using System;
using System.Collections.Generic;
using System.Text;


public interface IBuyer
{
    int food { get; }
    int age { get; }
    string name { get; }
    int BuyFood();
}

