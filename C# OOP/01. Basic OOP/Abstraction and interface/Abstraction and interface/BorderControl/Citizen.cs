using System;
using System.Collections.Generic;
using System.Text;


class Citizen : IBirthday
{
    public string birthDate { get; }
    public string name { get; }

    public Citizen(string name, string birthDate)
    {
        this.name = name;
        this.birthDate = birthDate;
    }
    
}

