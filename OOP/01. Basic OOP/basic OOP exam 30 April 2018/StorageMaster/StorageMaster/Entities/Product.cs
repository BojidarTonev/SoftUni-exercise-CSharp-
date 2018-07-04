using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities
{
    public abstract class Product
    {
        private double price;
        private double weight;

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }
        public double Weight
        {
            get { return weight; }
            protected set { weight = value; }
        }

        public double Price
        {
            get { return price; }
            protected set
            {
                price = value;
                if (price < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
            }
        }

    }
}
