using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Camping
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> result = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] tokens = input.Split(' ').ToArray();
                string name = tokens[0];
                string model = tokens[1];
                int timeToStay = int.Parse(tokens[2]);
                if (!result.ContainsKey(name))
                {
                    result.Add(name, new Dictionary<string, int>());
                    result[name].Add(model, timeToStay);
                }
                else
                {
                    if (!result[name].ContainsKey(model))
                    {
                        result[name].Add(model, timeToStay);
                    }
                    else
                    {
                        result[name][model] += timeToStay;
                    }
                }
            }
            foreach (var item in result.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key.Length))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var itemm in item.Value)
                {
                    Console.WriteLine($"***{itemm.Key}");
                }
                Console.WriteLine($"Total stay: {item.Value.Values.Sum()} nights");
            }
        }
    }
}
