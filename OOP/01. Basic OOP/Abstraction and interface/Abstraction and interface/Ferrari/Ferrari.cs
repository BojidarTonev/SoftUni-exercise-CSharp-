using System;
using System.Collections.Generic;
using System.Text;
using Ferrarrrii;


class Ferrari : ICar
{
    public const string Model = "488-Spider";

    private string driver;

    public Ferrari(string driver)
    {
        this.Driver = driver;
    }

    public string Driver
    {
        get { return driver; }
        set { driver = value; }
    }


    public string Brakes()
    {
        return "Brakes!";
    }

    public string Gas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{Model}/{Brakes()}/{Gas()}/{this.Driver}";
    }
}

