using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


class Car : Vehicle
{
    public Car(double fuelquantity, double fuelconsumption, int tankCapacity) 
        : base(fuelquantity, fuelconsumption, tankCapacity)
    {
    }

    public override void Drive(double distance)
    {
        if (distance * (FuelConsumptionKm + 0.9) <= FuelQuantity)
        {
            this.FuelQuantity -= distance * (FuelConsumptionKm + 0.9);
            Console.WriteLine($"Car travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Car needs refueling");
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

