using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using StorageMaster.Entities;
using StorageMaster.Products;

namespace StorageMaster.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            switch (type)
            {
                case "Gpu":
                    Gpu gpu = new Gpu(price);
                    return gpu;
                case "HardDrive":
                    HardDrive hardDrive = new HardDrive(price);
                    return hardDrive;
                case "Ram":
                    Ram ram = new Ram(price);
                    return ram;
                case "SolidStateDrive":
                    SolidStateDrive solidStateDrive = new SolidStateDrive(price);
                    return solidStateDrive;
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }
        }
    }
}
