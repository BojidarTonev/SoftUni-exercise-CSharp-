using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using StorageMaster.Entities;
using StorageMaster.Products;
using StorageMaster.Storages;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            switch (type)
            {
                case "AutomatedWarehouse":
                    AutomatedWarehouse automatedHouse = new AutomatedWarehouse(name);
                    return automatedHouse;
                case "DistributionCenter":
                    DistributionCenter distributionCenter = new DistributionCenter(name);
                    return distributionCenter;
                case "Warehouse":
                    Warehouse warehouse = new Warehouse(name);
                    return warehouse;;
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }
        }
    }
}
