using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities;

namespace StorageMaster.Products
{
    public class Ram : Product
    {
        public Ram(double price) 
            : base(price, 0.1)
        {
        }
    }
}
