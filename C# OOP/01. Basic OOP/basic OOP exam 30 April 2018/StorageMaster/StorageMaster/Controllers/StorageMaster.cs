using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageMaster.Entities;
using StorageMaster.Factories;

namespace StorageMaster.Controllers
{
    public class StorageMaster
    {
        private List<Product> pool;
        private List<Storage> storageRegistry;
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.pool = new List<Product>();
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.storageRegistry = new List<Storage>();
        }

        public string AddProduct(string type, double price)
        {
            Product product = productFactory.CreateProduct(type, price);
            this.pool.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = storageFactory.CreateStorage(type, name);
            this.storageRegistry.Add(storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.First(x => x.Name == storageName);
            Vehicle vehicle = storage.GetVehicle(garageSlot);

            this.currentVehicle = vehicle;

            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int addedItemsCount = 0;

            foreach (var productName in productNames)
            {
                if (!this.pool.Any(x => x.GetType().Name == productName))
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }
                Product product = this.pool.Last(x => x.GetType().Name == productName);
                this.currentVehicle.LoadProduct(product);
                this.pool.Remove(product);
                addedItemsCount++;
            }

            return $"Loaded {addedItemsCount}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storageRegistry.Any(x => x.Name == sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (!this.storageRegistry.Any(x => x.Name == destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Storage source = this.storageRegistry.First(x => x.Name == sourceName);
            Storage destination = this.storageRegistry.First(x => x.Name == destinationName);

            Vehicle vehicle = source.GetVehicle(sourceGarageSlot);

            int index = source.SendVehicleTo(sourceGarageSlot, destination);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {index})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.First(s => s.Name == storageName);

            Vehicle vehicle = storage.Garage.ToArray()[garageSlot];

            int beforeCount = vehicle.Trunk.Count;
            int count = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {count}/{beforeCount} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            var sb = new StringBuilder();
            Storage storage = this.storageRegistry.First(x => x.Name == storageName);
            List<Product> products = new List<Product>(storage.Products);

            sb.Append($"Stock ({storage.Products.Sum(x => x.Weight)}/{storage.Capacity}): ");

            sb.Append("[");

            int counter = 0;
            foreach (var product in products.GroupBy(x => x.GetType().Name).OrderByDescending(x => x.Count()).ThenBy(x => x.Key))
            {
                counter++;
                if (counter == products.Count - 1)
                {
                    sb.Append($"{product.Key} ({product.Count()})");
                }
                else
                {
                    sb.Append($"{product.Key} ({product.Count()}), ");
                }
            }

            sb.AppendLine("]");

            sb.Append("Garage: [");

            for (int i = 0; i < storage.Garage.Count; i++)
            {
                if (i == storage.Garage.Count - 1)
                {
                    if (storage.Garage.ToArray()[i] == null)
                    {
                        sb.Append($"empty");
                    }
                    else
                    {
                        sb.Append($"{storage.Garage.ToArray()[i].GetType().Name}");
                    }
                }
                else
                {
                    if (storage.Garage.ToArray()[i] == null)
                    {
                        sb.Append($"empty|");
                    }
                    else
                    {
                        sb.Append($"{storage.Garage.ToArray()[i].GetType().Name}|");
                    }
                }
            }

            sb.AppendLine("]");

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();
            foreach (var storage in storageRegistry.OrderByDescending(x => x.Products.Sum(k => k.Price)))
            {
                sb.AppendLine($"{storage.Name}:");
                sb.AppendLine($"Storage worth: ${storage.Products.Sum(x => x.Price):f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
