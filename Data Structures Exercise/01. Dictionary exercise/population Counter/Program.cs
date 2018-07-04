using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedDictionary<string, long>> result = new SortedDictionary<string, SortedDictionary<string, long>>();
            string input = Console.ReadLine();
            while (input != "report")
            {
                string[] tokens = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string city = tokens[0];
                string country = tokens[1];
                long population = long.Parse(tokens[2]);
                if (!result.ContainsKey(country))
                {
                    result.Add(country, new SortedDictionary<string, long>());
                    result[country].Add(city, population);
                }
                else
                {
                    result[country].Add(city, population);
                }

                input = Console.ReadLine();
            }
            foreach (var country in result.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum()})");
                foreach (var city in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
