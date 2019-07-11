using System;
using System.Collections.Generic;
using System.Text;


class Truck : Vehicle
{
    public Truck(double fuelquantity, double fuelconsumption, int tankCapacity) 
        : base(fuelquantity, fuelconsumption, tankCapacity)
    {
    }

    public override void Drive(double distance)
    {
        if (distance * (FuelConsumptionKm + 1.6) <= FuelQuantity)
        {
            this.FuelQuantity -= distance * (FuelConsumptionKm + 1.6);
            Console.WriteLine($"Truck travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Truck needs refueling");
        }
    }

    public override void Refuel(double fuel)
    {
        double space = FuelQuantity + fuel;
        if (space > TankCapacity)
        {
            Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
        }
        else
        {
            this.FuelQuantity += fuel;
        }
    }
}

