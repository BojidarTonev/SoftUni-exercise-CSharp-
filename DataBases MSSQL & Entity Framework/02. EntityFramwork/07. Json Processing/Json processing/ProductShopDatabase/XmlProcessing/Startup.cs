using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductShop.App.Dtos.Export;
using ProductShop.App.Dtos.Import;

namespace ProductShop.App
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using Data;
    using Models;
    using DataAnotations = System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization.Json;

    public class Startup
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile<ProductShopProfile>());
            var context = new ProductShopContext();
            string path = "../../../Json/users-and-products.json";
        }

        private static void ExportJsonUsersAndProducts(string path, ProductShopContext context)
        {
            var userss = context.Users
                .OrderByDescending(x => x.ProductsSold.Count)
                .ThenBy(x => x.LastName)
                .Where(u => u.ProductsSold.Count >= 1 && u.ProductsSold.Any(x => x.Buyer != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Count,
                        products = x.ProductsSold.Select(s => new
                        {
                            name = s.Name,
                            price = s.Price
                        })
                            .ToArray()
                     }
                }).ToArray();

            var users = new {usersCount = userss.Count(), users = userss.ToArray()};

            var jsonUsers = JsonConvert.SerializeObject(users, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            File.WriteAllText(path, jsonUsers);
        }

        private static void ExportJsonCategoriesByProducts(string path, ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new CategoryByProductDto()
                {
                    Name = c.Name,
                    ProductsCount = c.Products.Count,
                    AveragePrice = c.Products.Sum(p => p.Product.Price) / c.Products.Count(),
                    TotalRevenue = c.Products.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.ProductsCount)
                .ToArray();

            var jSonProducts = JsonConvert.SerializeObject(categories, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            File.WriteAllText(path, jSonProducts);
        }

        private static void ExportJsonSuccessfullySoldProducts(string path, ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .Select(u => new UserSoldProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Where(x => x.Buyer != null).Select(p => new SoldProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                        .ToArray()
                })
                .ToArray();

            var jsonProducts = JsonConvert.SerializeObject(users, Formatting.Indented);

            File.WriteAllText(path, jsonProducts);
        }

        private static void ExportJsonProductsInRange(string path, ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName ?? p.Seller.LastName
                })
                .OrderBy(p => p.Price);

            var jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented);
            
            File.WriteAllText(path, jsonProducts);
        }

        private static void ImportCategoryProducts(ProductShopContext context)
        {
            var categoryProducts = new List<CategoryProducts>();
            for (int productId = 201; productId <= 400; productId++)
            {
                var categoryId = new Random().Next(1, 12);

                var categoryProduct = new CategoryProducts()
                {
                    CategoryId = categoryId,
                    ProductId = productId
                };

                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        private static void ImportJsonCategories(string path, ProductShopContext context)
        {
            var json = File.ReadAllText(path);
            var jsonCategories = JsonConvert.DeserializeObject<CategoryDto[]>(json);

            var categories = new List<Category>();
            foreach (var jsonCategory in jsonCategories)
            {
                if (!IsValid(jsonCategory))
                {
                    continue;;
                }
                var category = Mapper.Map<Category>(jsonCategory);
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void ImportJsonProducts(string path, ProductShopContext context)
        {
            var json = File.ReadAllText(path);
            var jsonProducts = JsonConvert.DeserializeObject<ProductDto[]>(json);

            var products = new List<Product>();
            var random = new Random();

            foreach (var jsonProduct in jsonProducts)
            {
                if (!IsValid(jsonProduct))
                {
                    continue;
                }
                var product = Mapper.Map<Product>(jsonProduct);

                var sellerId = random.Next(1, 35);
                var buyerId = random.Next(35, 57);

                var randomm = random.Next(1, 4);

                product.SellerId = sellerId;
                product.BuyerId = buyerId;
                if (randomm == 3)
                {
                    product.BuyerId = null;
                }
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void ImportJsonUsers(string path, ProductShopContext context)
        {
            var json = File.ReadAllText(path);
            var jsonUsers = JsonConvert.DeserializeObject<UserDto[]>(json);

            var users = new List<User>();
            foreach (var jsonUser in jsonUsers)
            {
                var user = Mapper.Map<User>(jsonUser);
                if (IsValid(user))
                {
                    users.Add(user);
                }
            }

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
