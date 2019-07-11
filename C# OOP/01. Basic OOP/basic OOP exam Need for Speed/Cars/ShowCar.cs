using System;
using System.Collections.Generic;
using System.Text;


public class ShowCar:Car
{
    private int stars;

    public ShowCar(string brand, string model, int year, int hp, int acceleration, int suspension, int durability) 
        : base(brand, model, year, hp, acceleration, suspension, durability)
    {
        this.stars = 0;
    }

    public int Stars
    {
        get { return stars; }
        set { stars = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"{this.Stars} *");

        return sb.ToString().TrimEnd();
    }
}

