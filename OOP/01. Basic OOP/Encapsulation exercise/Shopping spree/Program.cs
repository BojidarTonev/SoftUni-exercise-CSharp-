using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Shopping_spree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    string[] input = Console.ReadLine().Split(new char[] { '=', ';'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    CreatePerson(input, people);                    
                }
                else
                {
                    string[] input = Console.ReadLine().Split(new char[]{ '=', ';'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    CreateProduct(input, products);                                      
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string personName = tokens[0];
                string productName = tokens[1];

                double productPrice = products.Find(x=>x.Name.Equals(productName)).Cost;

                ShoppingTheProducts(people, personName, productPrice, productName);                
            }
            Print(people);            
        }

        private static void CreateProduct(string[] input, List<Product>products)
        {
            for (int j = 0; j < input.Length; j += 2)
            {
                string productName = input[j];
                double productPrice = double.Parse(input[j + 1]);
                Product product = new Product(productName, productPrice);
                products.Add(product);
            }
        }

        private static void CreatePerson(string[] input, List<Person>people)
        {
            for (int j = 0; j < input.Length; j += 2)
            {
                string name = input[j];
                double money = double.Parse(input[j + 1]);
                try
                {
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void ShoppingTheProducts(List<Person>people, string personName, double productPrice, string productName)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].Name.Equals(personName))
                {
                    if (people[i].Money < productPrice)
                    {
                        Console.WriteLine($"{people[i].Name} can't afford {productName}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{people[i].Name} bought {productName}");
                        people[i].Money -= productPrice;
                        people[i].ProductsList.Add(productName);
                        break;
                    }
                }
            }
        }

        private static void Print(List<Person>people)
        {
            foreach (var person in people)
            {
                if (person.ProductsList.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.ProductsList)}");
                }
            }
        }
    }
}
