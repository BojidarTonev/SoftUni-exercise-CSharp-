using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<double, string>>result = new Dictionary<string, Dictionary<double, string>>();
            string input = Console.ReadLine();
            string resultPattern = @"([A-Z]{2})([\d]+\.[\d]+)([a-zA-Z]+)\|";
            while (true)
            {
                if (input == "end")
                {
                    break;
                }
                foreach (Match m in Regex.Matches(input, resultPattern))
                {
                    string capital = m.Groups[1].Value;
                    double temp = double.Parse(m.Groups[2].Value);
                    string last = m.Groups[3].Value;

                    if (!result.ContainsKey(capital))
                    {
                        result.Add(capital, new Dictionary<double, string>());
                        result[capital].Add(temp, last);
                    }
                    else
                    {
                        result[capital].Clear();
                        result[capital].Add(temp, last);
                    }
                }
                input = Console.ReadLine();
            }
            result = result.OrderBy(x => x.Value.Keys.Max()).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in result)
            {
                Console.Write($"{item.Key} => ");
                foreach (var value in item.Value.OrderByDescending(x=>x.Key))
                {
                    Console.Write($"{value.Key:f2} => ");
                    Console.Write($"{value.Value}");
                    Console.WriteLine();
                }
            }
        }
    }
}
