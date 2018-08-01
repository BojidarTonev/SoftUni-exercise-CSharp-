namespace ProductShop.App
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using AutoMapper;
    using Dtos.Export;
    using Dtos.Import;
    using Data;
    using Models;
    using DataAnotations = System.ComponentModel.DataAnnotations;

    public class Startup
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile<ProductShopProfile>());
            var context = new ProductShopContext();

            //ImportXmlUserData("..\\..\\..\\Xml\\users.xml");
            //ImportXmlProductsData("..\\..\\..\\Xml\\products.xml");
            //ImportXmlCategoriesData("..\\..\\..\\Xml\\categories.xml");
            //ImportCategoryProductsData(context);

            //ExportExmlProductsInRange(context);
            //ExportXmlCategoriesByProductCount(context);
            XportXmlUsersAndProducts(context);

        }

        private static void XportXmlUsersAndProducts(ProductShopContext context)
        {
            var users = new UsersDto()
            {
                Count = context.Users.Count(),
                Users = context.Users
                    .Where(x => x.ProductsSold.Count >= 1)
                    .Select(u => new UsersDtoo()
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age.ToString(),
                        SoldProducts = u.ProductsSold.Select(s => new SoldProductsDto()
                            {
                                Count = u.ProductsSold.Count,
                                SoldProducts = u.ProductsSold.Select(k => new SoldProductDto()
                                    {
                                        Name = k.Name,
                                        Price = k.Price
                                    })
                                    .ToArray()
                            })
                            .ToArray()
                    })
                    .ToArray()
            };

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] {XmlQualifiedName.Empty});

            var serizlier = new XmlSerializer(typeof(UsersDto), new XmlRootAttribute("users"));
            serizlier.Serialize(new StringWriter(sb), users, xmlNamespaces);

            File.WriteAllText("../../../Xml/users-and-products.xml", sb.ToString());
        }

        private static void ExportXmlCategoriesByProductCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(x => x.Products.Count)
                .Select(c => new CategoryDto2()
                {
                    Name = c.Name,
                    ProductsCount = c.Products.Count,
                    TotalRevenue = c.Products.Sum(s => s.Product.Price),
                    AveragePrice = c.Products.Select(s => s.Product.Price).DefaultIfEmpty(0).Average()
                })
                .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new []{XmlQualifiedName.Empty});

            var serializer = new XmlSerializer(typeof(CategoryDto2[]), new XmlRootAttribute("categories"));
            serializer.Serialize(new StringWriter(sb), categories, xmlNamespaces);

            File.WriteAllText("../../../Xml/categories-by-products.xml", sb.ToString());

        }

        private static void ExportXmlSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new UserDto2()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(y => new SoldProductDto()
                        {
                            Name = y.Name,
                            Price = y.Price
                        })
                        .ToArray()
                })
                .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] {XmlQualifiedName.Empty});

            var serializer = new XmlSerializer(typeof(UserDto2[]), new XmlRootAttribute("users"));
            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            File.WriteAllText("../../../Xml/users-sold-products.xml", sb.ToString());
        }

        private static void ExportExmlProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.Buyer != null)
                .Select(p => new ProductDto2()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName ?? p.Buyer.LastName
                })
                .ToArray();

            //List<ProductDto2> dtos = new List<ProductDto2>();
            //foreach (var product in products)   
            //{
            //    var dto = Mapper.Map<ProductDto2>(product);
            //    dtos.Add(dto);
            //}

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] {XmlQualifiedName.Empty});

            var serializer = new XmlSerializer(typeof(ProductDto2[]), new XmlRootAttribute("products"));
            serializer.Serialize(new StringWriter(sb), products, xmlNamespaces);

            File.WriteAllText("../../../Xml/products-in-range.xml", sb.ToString());
        }

        private static void ImportCategoryProductsData(ProductShopContext context)
        {
            var products = context.Products.ToList();
            foreach (var product in products)
            {
                int categoryId = new Random().Next(1, 12);
                int productId = product.Id;

                var categoryProduct = new CategoryProducts() { CategoryId = categoryId, ProductId = productId };
                context.CategoryProducts.Add(categoryProduct);
                context.SaveChanges();
            }
        }

        private static void ImportXmlCategoriesData(string path)
        {
            var xmlString = File.ReadAllText(path);

            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("categories"));
            var deserializedCategories = (CategoryDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Category> categories = new List<Category>();

            foreach (var categoryDto in deserializedCategories)
            {
                if (!IsValid(categoryDto))
                {
                    continue;
                }
                var category = Mapper.Map<Category>(categoryDto);
                categories.Add(category);
            }

            var context = new ProductShopContext();
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void ImportXmlProductsData(string path)
        {
            var xmlString = File.ReadAllText(path);

            //var xmlNamespace = new XmlSerializerNamespaces(new [] {XmlQualifiedName.Empty});
            var serializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("products"));
            var deserializedProducts = (ProductDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Product> products = new List<Product>();

            int counter = 1;

            foreach (var productDto in deserializedProducts)
            {
                if (!IsValid(productDto))
                {
                    continue;
                }
                int buyerId = new Random().Next(1, 35);
                int sellerId = new Random().Next(25, 57);

                var product = Mapper.Map<Product>(productDto);

                if (counter == 4)
                {
                    counter = 1;
                    product.BuyerId = null;
                    product.SellerId = sellerId;
                    products.Add(product);
                    continue;
                }
                product.BuyerId = buyerId;
                product.SellerId = sellerId;

                products.Add(product);

                counter++;
            }

            var context = new ProductShopContext();
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void ImportXmlUserData(string path)
        {
            var xmlString = File.ReadAllText(path);

            var serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("users"));
            var deserializerUsers = (UserDto[])serializer.Deserialize(new StringReader(xmlString));

            List<User> users = new List<User>();

            foreach (var userDto in deserializerUsers)
            {
                if (!IsValid(userDto))
                {
                    continue;
                }
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }

            var context = new ProductShopContext();
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new DataAnotations.ValidationContext(obj);
            var validationResults = new List<DataAnotations.ValidationResult>();

            return DataAnotations.Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
