using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities;
using StorageMaster.Vehicles;

namespace StorageMaster.Storages
{
    public class Warehouse : Storage
    {
        public Warehouse(string name) 
            : base(name, 10, 10, new Semi(), new Semi(), new Semi())
        {
        }
    }
}
