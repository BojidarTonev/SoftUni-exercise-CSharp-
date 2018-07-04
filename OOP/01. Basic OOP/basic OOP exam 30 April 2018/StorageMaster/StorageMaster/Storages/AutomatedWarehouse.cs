using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities;
using StorageMaster.Vehicles;

namespace StorageMaster.Storages
{
    public class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(string name) 
            : base(name, 1, 2, new Truck())
        {
        }
    }
}
