using System;
using System.Collections.Generic;
using System.Text;

class Pet : IBirthday
{
    public string name { get; }
    public string birthDate { get; }

    public Pet(string name, string birthDate)
    {
        this.name = name;
        this.birthDate = birthDate;
    }
}

