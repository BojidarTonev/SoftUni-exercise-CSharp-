using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.App.Dtos.Import;
using CarDealer.App.Dtos.Xport;
using CarDealer.Models;
using CarDealers.Data;

namespace CarDealer.App
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<CarDealerProfile>());
            var context = new CarDealerContext();
            string path = "../../../Xml/sales-discounts.xml";
            //ImprotXmlSuppliers(path, context);
            //ImportXmlParts(path, context);
            //ImportXmlCars(path, context);
            //ImportXmlCustomers(path, context);
            //ImportSales(context);
            //ExportXmlCarsWithDistance(context, path);
            //ExportXmlCarsFromMakeFerrari(context, path);
            //ExportXmlLocalSuppliers(context, path);
            //ExportXmlCarsWithTheirListOfParts(context, path);
            //ExportXmlTotalSalesByCustomer(context, path);
            ExportSalesWithDisscount(context, path);
        }

        private static void ExportSalesWithDisscount(CarDealerContext context, string path)
        {
            var sales = context.Sales
                .Select(s => new ExportSaleDto()
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = (int) s.Car.TravelledDistance,
                    CustomerName = s.Customer.Name,
                    Disscount = s.Discount,
                    Price = s.Customer.Cars.Sum(x => x.Car.Parts.Select(p => p.Part.Price).Sum()),
                    PriceWithDiscount = s.Customer.Cars.Sum(x => x.Car.Parts.Select(p => p.Part.Price).Sum()) -
                                        (s.Customer.Cars.Sum(x => x.Car.Parts.Select(p => p.Part.Price).Sum()) *
                                         s.Discount)
                })
                .ToArray();

            var sb = new StringBuilder();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(ExportSaleDto[]), new XmlRootAttribute("sales"));
            serializer.Serialize(new StringWriter(sb), sales, xmlNamespaces);

            File.WriteAllText(path, sb.ToString());
        }

        private static void ExportXmlTotalSalesByCustomer(CarDealerContext context, string path)
        {
            var customers = context.Customers
                .Where(c => c.Cars.Count >= 1)
                .Select(c => new ExportCustomerDto()
                {
                    FullName = c.Name,
                    BoughtCarsr = c.Cars.Count,
                    SpentMoney = c.Cars.Sum(x => x.Car.Parts.Select(p => p.Part.Price).Sum())
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCarsr)
                .ToArray();

            var sb = new StringBuilder();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(ExportCustomerDto[]), new XmlRootAttribute("customers"));
            serializer.Serialize(new StringWriter(sb), customers, xmlNamespaces);

            File.WriteAllText(path, sb.ToString());
        }

        private static void ExportXmlCarsWithTheirListOfParts(CarDealerContext context, string path)
        {
            var cars = context.Cars
                .Select(c => new ExportCarDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.Parts.Select(p => new ExportPartDto()
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .ToArray()
                })
                .ToArray();

            var sb = new StringBuilder();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(ExportCarDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), cars, xmlNamespaces);

            File.WriteAllText(path, sb.ToString());
        }

        private static void ExportXmlLocalSuppliers(CarDealerContext context, string path)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new LocalSuppliersDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            var sb = new StringBuilder();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(LocalSuppliersDto[]), new XmlRootAttribute("suppliers"));
            serializer.Serialize(new StringWriter(sb), suppliers, xmlNamespaces);

            File.WriteAllText(path, sb.ToString());
        }

        private static void ExportXmlCarsFromMakeFerrari(CarDealerContext context, string path)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Ferrari")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarsFromMakeFerrariDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            var sb = new StringBuilder();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(CarsFromMakeFerrariDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), cars, xmlNamespaces);

            File.WriteAllText(path, sb.ToString());
        }

        private static void ExportXmlCarsWithDistance(CarDealerContext context, string path)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance >= 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new CarDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            var sb = new StringBuilder();

            var xmlNamespaces = new XmlSerializerNamespaces(new[]{ XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(CarDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), cars, xmlNamespaces);

            File.WriteAllText(path, sb.ToString());
        }

        private static void ImportSales(CarDealerContext context)
        {
            var carId = new Random().Next(1, context.Cars.Count());
            var customerId = new Random().Next(1, context.Customers.Count());

            var discounts = new List<decimal>() {5, 10, 15, 20, 30, 40, 50};
            
            var sale = new Sale(){CarId = carId, CustomerId = customerId};
            if (context.Customers.First(c => c.Id == customerId).IsYoungDriver)
            {
                int disscountIndex = new Random().Next(0, 8);
                var discount = discounts.ElementAt(disscountIndex);
                sale.Discount = discount;
            }
            else
            {
                sale.Discount = 0;
            }

            context.Sales.Add(sale);
            context.SaveChanges();
        }

        private static void ImportXmlCustomers(string path, CarDealerContext context)
        {
            var xmlString = File.ReadAllText(path);

            var serializer = new XmlSerializer(typeof(CustomerDto[]), new XmlRootAttribute("customers"));
            var deserializedCustomers = (CustomerDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Customer> customers = new List<Customer>();

            foreach (var customerDto in deserializedCustomers)
            {
                var customer = Mapper.Map<Customer>(customerDto);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        private static void ImportXmlCars(string path, CarDealerContext context)
        {
            var xmlString = File.ReadAllText(path);

            var serializer = new XmlSerializer(typeof(CarDto[]), new XmlRootAttribute("cars"));
            var serializedCars = (CarDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Car> cars = new List<Car>();
            var randomNumbers = new List<int>();

            foreach (var carDto in serializedCars)
            {
                var car = Mapper.Map<Car>(carDto);

                for (int i = 10; i < new Random().Next(10, 21); i++)
                {
                    bool finish = true;
                    while (finish)
                    {
                        int partId = new Random().Next(1, 132);
                        if (!randomNumbers.Contains(partId))
                        {
                            randomNumbers.Add(partId);
                            var partCar = new PartCars() { PartId = partId, CarId = car.Id };
                            car.Parts.Add(partCar);
                            finish = false;
                        }
                    }
                }

                cars.Add(car);
                randomNumbers.Clear();
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        private static void ImportXmlParts(string path, CarDealerContext context)
        {
            var xmlString = File.ReadAllText(path);

            var serializer = new XmlSerializer(typeof(PartDto[]), new XmlRootAttribute("parts"));
            var deserializedParts = (PartDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Part> parts = new List<Part>();

            foreach (var partDto in deserializedParts)
            {
                int supplierId = new Random().Next(1, 32);
                var part = Mapper.Map<Part>(partDto);
                part.SupplierId = supplierId;
                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();
        }

        private static void ImprotXmlSuppliers(string path, CarDealerContext context)
        {
            var xmlString = File.ReadAllText(path);

            var serializer = new XmlSerializer(typeof(SupplierDto[]), new XmlRootAttribute("suppliers"));
            var deserializedSuppliers = (SupplierDto[]) serializer.Deserialize(new StringReader(xmlString));

            List<Supplier> suppliers = new List<Supplier>();

            foreach (var supplierDto in deserializedSuppliers)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }
    }
}
