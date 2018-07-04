using System;
using System.Collections.Generic;
using System.Text;


class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption + 1.4, tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
    }

}

