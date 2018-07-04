using System;
using System.Collections.Generic;
using System.Text;


public class UltrasoftTyre:Tyre
{
    private double grip;

    public UltrasoftTyre(double hardness, double grip) 
        : base(hardness)
    {
        base.Name = "Ultrasoft";
        this.Grip = grip;
    }

    public double Grip
    {
        get { return grip; }
        protected set { grip = value; }
    }

    public override void DegradeTyre()
    {
        if (this.Degradation - (this.Hardness + this.Grip) < 30)
        {
            throw new ArgumentException("Blown Tyre");
        }
        else
        {
            this.Degradation -= this.Hardness + this.Grip;
        }
    }
}

