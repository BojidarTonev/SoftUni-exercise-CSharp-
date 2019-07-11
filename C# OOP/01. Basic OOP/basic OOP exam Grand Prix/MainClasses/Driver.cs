using System;
using System.Collections.Generic;
using System.Text;


public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;
    private double speed;
    public string failiure = "";

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
        this.Speed = (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
    }

    public double Speed
    {
        get { return speed; }
        protected set { speed = value; }
    }

    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        protected set { fuelConsumptionPerKm = value; }
    }

    public Car Car
    {
        get { return car; }
        protected set { car = value; }
    }

    public double TotalTime
    {
        get { return totalTime; }
        set { totalTime = value; }
    }

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

}

