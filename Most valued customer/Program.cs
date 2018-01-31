using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Most_valued_customer
{
    class Program
    {
        static void Main(string[] args)
        {
            var shopList = new Dictionary<string, double>();
            List<Customer> customers = new List<Customer>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Shop is open")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split(' ').ToArray();
                    string name = tokens[0];
                    double price = double.Parse(tokens[1]);
                    shopList.Add(name, price);
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Print")
                {
                    break;
                }
                if (input == "Discount")
                {
                    var topThree = shopList.OrderByDescending(x => x.Value).Take(3).ToList();

                    foreach (var product in topThree)
                    {
                        shopList[product.Key] -= shopList[product.Key] * 0.1;
                    }
                }
                else
                {
                    string[] tokens = input.Split(' ', ':', ',').ToArray();
                    string name = tokens[0];
                    Customer customer = new Customer() { Name = name, BuyedMaterals = new Dictionary<string, int>() };
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        if (shopList.ContainsKey(tokens[i]))
                        {
                            if (customer.BuyedMaterals.ContainsKey(tokens[i]))
                            {
                                customer.BuyedMaterals[tokens[i]] += 1;
                            }
                            else
                            {
                                customer.BuyedMaterals.Add(tokens[i], 1);
                            }
                        }
                    }
                    customer.MoneySpent = 0;
                    customers.Add(customer);
                }
            }
            foreach (var customer in customers)
            {
                foreach (var kvp in customer.BuyedMaterals)
                {
                    customer.MoneySpent += kvp.Value * shopList[kvp.Key];
                }
            }
            foreach (var customer in customers)
            {
                Console.WriteLine($"Biggest spender: {customer.Name}");
                Console.WriteLine($"^Products bought:");
                foreach (var item in customer.BuyedMaterals)
                {
                    Console.WriteLine($"^^^{item.Key}: {item.Value:f2}");
                }
                Console.WriteLine($"Total: {customer.MoneySpent:f2}");
                break;
            }
        }
    }
    public class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> BuyedMaterals { get; set; }
        public double MoneySpent { get; set; }
    }
}
