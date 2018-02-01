using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities_by_continent_and_country
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> result = new Dictionary<string, Dictionary<string, List<string>>>();
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string continent = input[0];
                string country = input[1];
                string city = input[2];
                if (!result.ContainsKey(continent))
                {
                    result.Add(continent, new Dictionary<string, List<string>>());
                    if (!result[continent].ContainsKey(country))
                    {
                        result[continent].Add(country, new List<string>());
                        result[continent][country].Add(city);
                    }
                }
                else
                {
                    if (!result[continent].ContainsKey(country))
                    {
                        result[continent].Add(country, new List<string>());
                        result[continent][country].Add(city);
                    }
                    else
                    {
                        result[continent][country].Add(city);
                    }
                }
            }
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var country in item.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
