using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix_oscar
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "Blaze it!")
            {
                string[] tokens = input.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string creature = tokens[0];
                string squadMate = tokens[1];
                if (!result.ContainsKey(creature))
                {
                    result.Add(creature, new List<string>());
                    if (!result[creature].Contains(squadMate) && squadMate != creature)
                    {
                        result[creature].Add(squadMate);
                    }
                }
                else
                {
                    if (!result[creature].Contains(squadMate) && squadMate != creature)
                    {
                        result[creature].Add(squadMate);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var item in result.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{item.Key} : {item.Value.Count}");
            }
        }
    }
}