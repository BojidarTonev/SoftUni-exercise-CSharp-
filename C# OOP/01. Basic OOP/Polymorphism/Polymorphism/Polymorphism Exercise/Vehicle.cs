using System;
using System.Collections.Generic;
using System.Text;


public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumptionKm;
    private int tankCapacity;

    public Vehicle(double fuelquantity, double fuelconsumption, int tankCapacity)
    {
        this.FuelQuantity = fuelquantity;
        this.FuelConsumptionKm = fuelconsumption;
        this.TankCapacity = tankCapacity;
    }

    public int TankCapacity
    {
        get { return tankCapacity; }
        set
        {
            tankCapacity = value;
        }
    }

    public double FuelConsumptionKm
    {
        get { return fuelConsumptionKm; }
        set
        {
            fuelConsumptionKm = value;
        }
    }

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set
        {
            if (fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
            }
            else
            {
                fuelQuantity = value;
            }           
        }
    }

    public virtual void Drive(double distance)
    {

    }

    public virtual void Refuel(double fuel)
    {
        
    }
}

