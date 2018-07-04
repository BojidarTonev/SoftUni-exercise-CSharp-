using System;
using System.Collections.Generic;
using System.Text;


class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
        : base(fuelQuantity, fuelConsumption + 1.6, tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
    }

    public override void Refuel(double fuelAmount)
    {
        double realamount = fuelAmount * 0.95;
        if (fuelAmount <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else if (fuelAmount > this.TankCapacity)
        {
            Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
        }
        else
        {
            this.FuelQuantity += fuelAmount;
        }
    }
}

