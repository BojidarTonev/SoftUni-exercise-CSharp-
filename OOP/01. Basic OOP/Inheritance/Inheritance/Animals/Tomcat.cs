using System;
using System.Collections.Generic;
using System.Text;


class Tomcat : Cat
{
    public Tomcat(string name, int age, string gender = "Male")
        : base(name, age, gender)
    {
        base.Gender = "Male";
    }

    public override string ProduceSound()
    {
        return "MEOW";
    }
}

