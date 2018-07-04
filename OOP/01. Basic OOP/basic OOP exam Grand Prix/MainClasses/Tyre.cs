using System;
using System.Collections.Generic;
using System.Text;


public abstract class Tyre
{
    private string name;
    private double hardness;
    private double degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.degradation = 100;
    }

    public double Degradation
    {
        get { return degradation; }
        protected set { degradation = value; }
    }
    public double Hardness
    {
        get { return hardness; }
        private set { hardness = value; }
    }

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    public virtual void DegradeTyre()
    {
        if (this.Degradation - this.Hardness <= 0)
        {
            throw new ArgumentException("Blown Tyre");
        }
        else
        {
            this.Degradation -= this.Hardness;
        }
    }

}

