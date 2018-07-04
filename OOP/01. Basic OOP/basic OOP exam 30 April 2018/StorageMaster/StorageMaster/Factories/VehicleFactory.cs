using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using StorageMaster.Entities;
using StorageMaster.Vehicles;

namespace StorageMaster.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            switch (type)
            {
                case "Semi":
                    Semi semi = new Semi();
                    return semi;
                case "Truck":
                    Truck truck = new Truck();
                    return truck;
                case "Van":
                    Van van = new Van();
                    return van;
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }
        }
    }
}
