using System;
using System.Collections.Generic;
using System.Text;


class Kitten : Cat
{
    public Kitten(string name, int age, string gender = "Female")
        : base(name, age, gender)
    {
        base.Gender = "Female";
    }

    public override string ProduceSound()
    {
       return "Meow";
    }
}

