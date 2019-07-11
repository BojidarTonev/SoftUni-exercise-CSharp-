using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities;

namespace StorageMaster.Products
{
    public class Gpu : Product
    {
        public Gpu(double price) 
            : base(price, 0.7)
        {
        }
    }
}
