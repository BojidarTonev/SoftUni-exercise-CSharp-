using System;
using System.Collections.Generic;
using System.Linq;

namespace RainAir
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<long>>result = new SortedDictionary<string, List<long>>();
            List<long>flights = new List<long>();
            string input = Console.ReadLine();
            while (input!="I believe I can fly!")
            {
                string[]tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (tokens.Contains("="))
                {
                    string firstCustomer = tokens[0];
                    string secondCustomer = tokens[2];
                    foreach (var customer in result)
                    {
                        if (customer.Key.Equals(secondCustomer))
                        {
                            foreach (var fly in customer.Value)
                            {
                                flights.Add(fly);
                            }
                        }
                    }
                    foreach (var customer in result)
                    {
                        if (customer.Key.Equals(firstCustomer))
                        {
                            customer.Value.Clear();
                            foreach (var flight in flights)
                            {
                                customer.Value.Add(flight);
                            }
                        }
                    }
                    flights.Clear();
                }
                else
                {
                    string customerName = tokens[0];
                    if (!result.ContainsKey(customerName))
                    {
                        result.Add(customerName, new List<long>());
                        for (long i = 1; i < tokens.Length; i++)
                        {
                            long flight = long.Parse(tokens[i]);
                            result[customerName].Add(flight);
                        }
                    }
                    else
                    {
                        for (long i = 1; i < tokens.Length; i++)
                        {
                            long flight = long.Parse(tokens[i]);
                            result[customerName].Add(flight);
                        }
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var customer in result.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"#{customer.Key} ::: {string.Join(", ", customer.Value.OrderBy(x=>x))}");
            }
        }
    }
}
