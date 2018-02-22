using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private string model;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    private int power;

    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    private string displacement;

    public string Displacement
    {
        get { return displacement; }
        set { displacement = value; }
    }

    private string efficency;

    public string Efficency
    {
        get { return efficency; }
        set { efficency = value; }
    }

    public Engine()
    {

    }

    public Engine(string model, int power)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = "n/a";
        this.Efficency = "n/a";
    }

    public Engine(string model, int power, string efficency)
       
    {
        this.Model = model;
        this.Power = power;
        this.Efficency = efficency;
        this.Displacement = "n/a";
    }

    public Engine(string model, int power, int displacement)
       
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement.ToString();
        this.Efficency = "n/a";
    }

    public Engine(string model, int power, int displacement, string efficency)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement.ToString();
        this.Efficency = efficency;
    }
}

