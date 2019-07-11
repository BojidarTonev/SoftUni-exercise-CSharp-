using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities;

namespace StorageMaster.Products
{
    public class SolidStateDrive : Product
    {
        public SolidStateDrive(double price) 
            : base(price, 0.2)
        {
        }
    }
}
