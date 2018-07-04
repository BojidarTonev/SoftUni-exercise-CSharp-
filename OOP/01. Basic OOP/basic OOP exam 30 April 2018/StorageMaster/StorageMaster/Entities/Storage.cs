using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities
{
    public class Storage
    {
        private Vehicle[] _garage;
        private List<Product> _products;

        public Storage(string name, int capacity, int garageSlots, params Vehicle[] vehicles)
        {
            this._products = new List<Product>();
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this._garage = new Vehicle[this.GarageSlots];
            for (int i = 0; i < vehicles.Length; i++)
            {
                this._garage[i] = vehicles[i];
            }
        }

        public string Name { get; }

        public int Capacity { get; }

        public int GarageSlots { get; }

        public IReadOnlyCollection<Vehicle> Garage => this._garage;

        public IReadOnlyCollection<Product> Products => this._products;

        public bool IsFull => this.Products.Sum(x => x.Weight) >= this.Capacity;

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            if (this._garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return this._garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = GetVehicle(garageSlot);

            if (!deliveryLocation.Garage.Any(x => x == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this._garage[garageSlot] = null;

            Vehicle indexer = deliveryLocation.Garage.First(x => x == null);
            int index = deliveryLocation.Garage.ToList().IndexOf(indexer);

            deliveryLocation._garage[index] = vehicle;

            return index;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = GetVehicle(garageSlot);

            int numberProducts = 0;

            while (vehicle.Trunk.Count != 0 || this.IsFull)
            {
                Product product = vehicle.Unload();
                this._products.Add(product);
                numberProducts++;
            }

            return numberProducts;
        }
    }
}
