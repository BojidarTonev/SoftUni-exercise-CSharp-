using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.FuelAmount = fuelAmount;
        this.Hp = hp;
        this.Tyre = tyre;
    }

    public Tyre Tyre
    {
        get { return tyre; }
        set { tyre = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        set
        {
            if (value > 160 || value < 0)
            {
                fuelAmount = 160;
            }
            else
            {
                fuelAmount = value;
            }
        }
    }

    public int Hp
    {
        get { return hp; }
        protected set { hp = value; }
    }
}

