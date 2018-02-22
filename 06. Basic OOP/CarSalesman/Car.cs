using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private Engine eginee;

    public Engine Enginee
    {
        get { return eginee; }
        set { eginee = value; }
    }

    private string model;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    private string engine;

    public string Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    private string weight;

    public string Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    private string color;

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    
    public Car(string model, string engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = "n/a";
        this.Color = "n/a";
    }

    public Car(string model, string engine, int weight)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight.ToString();
        this.Color = "n/a";
    }

    public Car(string model, string engine, string color)
    {
        this.Model = model;
        this.Engine = engine;
        this.Color = color;
        this.Weight = "n/a";
    }

    public Car(string model, string engine, string weight, string color)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }
}

