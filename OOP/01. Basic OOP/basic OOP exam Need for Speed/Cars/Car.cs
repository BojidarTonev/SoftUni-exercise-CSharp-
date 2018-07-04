using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;


public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsePower;
    private int acceleration;
    private int suspension;
    private int durability;
    private bool isAvailable;

  
    protected Car(string brand, string model, int year, int hp, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = year;
        this.HorsePower = hp;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
        this.IsAvailable = true;
    }

    public int Durability
    {
        get { return durability; }
        protected set { durability = value; }
    }

    public int Suspension
    {
        get { return suspension; }
        set { suspension = value; }
    }

    public int Acceleration
    {
        get { return acceleration; }
        protected set { acceleration = value; }
    }

    public int HorsePower
    {
        get { return horsePower; }
        set { horsePower = value; }
    }

    public int YearOfProduction
    {
        get { return yearOfProduction; }
        protected set { yearOfProduction = value; }
    }

    public string Model
    {
        get { return model; }
        protected set { model = value; }
    }

    public string Brand
    {
        get { return brand; }
        protected set { brand = value; }
    }

    public bool IsAvailable
    {
        get { return this.isAvailable; }
        set { this.isAvailable = value; }
    }


    public double CasualPerformance => (this.HorsePower / this.Acceleration) + (this.Suspension + this.Durability);

    public double DragPerformance => (this.HorsePower / this.Acceleration);

    public double DriftPerformance => this.Suspension + this.Durability;

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");
        sb.AppendLine($"{this.HorsePower} HP, 100 m/h in {this.Acceleration} s");
        sb.AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return sb.ToString().TrimEnd();
    }
}

