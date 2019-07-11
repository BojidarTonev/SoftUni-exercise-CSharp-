using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;


public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int year, int hp, int acceleration, int suspension, int durability) 
        : base(brand, model, year, hp, acceleration, suspension, durability)
    {
        this.HorsePower += hp / 2;
        this.Suspension -= suspension / 4;
        this.addOns = new List<string>();
    }

    public List<string> AddOns
    {
        get { return addOns; }
        protected set { addOns = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        if (addOns.Count == 0)
        {
            sb.AppendLine("Add-ons: None");
        }
        else
        {
            sb.Append($"Add-ons: ");
            sb.Append($"{string.Join(", ", this.AddOns)}");

        }





        return sb.ToString().TrimEnd();
    }
}

