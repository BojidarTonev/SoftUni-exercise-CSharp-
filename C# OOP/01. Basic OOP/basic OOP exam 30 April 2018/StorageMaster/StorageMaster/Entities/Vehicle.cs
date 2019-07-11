using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities
{
    public abstract class Vehicle
    {
        public int Capacity { get; }

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this._products = new List<Product>();
        }

        public IReadOnlyCollection<Product> Trunk => this._products;

        private List<Product> _products;

        public bool IsFull => this.Trunk.Sum(x => x.Weight) >= this.Capacity;

        public bool IsEmpty => this.Trunk.Count == 0;

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            this._products.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            Product product = this._products.Last();
            this._products.Remove(product);

            return product;
        }
    }
}
