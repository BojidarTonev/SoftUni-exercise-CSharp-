using System;
using System.Collections.Generic;
using System.Text;


class Bus : Vehicle
{
    public Bus(double fuelquantity, double fuelconsumption, int tankCapacity) 
        : base(fuelquantity, fuelconsumption, tankCapacity)
    {
    }

    public void DriveEmpty(double distance)
    {
        if (distance * FuelConsumptionKm <= FuelQuantity)
        {
            this.FuelQuantity -= distance * FuelConsumptionKm;
            Console.WriteLine($"Bus travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Bus needs refueling");
        }
    }

    public void DriveFull(double distance)
    {
        if (distance * (FuelConsumptionKm + 1.4 ) <= FuelQuantity)
        {
            this.FuelQuantity -= distance * (FuelConsumptionKm + 1.4);
            Console.WriteLine($"Bus travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Bus needs refueling");
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

