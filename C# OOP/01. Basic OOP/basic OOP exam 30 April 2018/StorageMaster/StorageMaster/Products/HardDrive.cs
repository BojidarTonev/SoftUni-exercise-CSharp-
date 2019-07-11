using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities;

namespace StorageMaster.Products
{
    public class HardDrive : Product
    {
        public HardDrive(double price) 
            : base(price, 1)
        {
        }
    }
}
