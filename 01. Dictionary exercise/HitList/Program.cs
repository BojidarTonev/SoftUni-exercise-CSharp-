using System;
using System.Collections.Generic;
using System.Linq;

namespace HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            string zapodozrqn = "";
            int infoIndex = int.Parse(Console.ReadLine());
            var result = new Dictionary<string, Dictionary<string, string>>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input[0] == 'K' && input[1] == 'i' && input[2] == 'l' && input[3] == 'l')
                {
                    var newinput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    zapodozrqn = newinput[1];
                    break;
                }
                var tokens = input.Split(new char[] { '=', ':', ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string name = tokens[0];
                tokens.RemoveAt(0);
                if (!result.ContainsKey(name))
                {
                    result.Add(name, new Dictionary<string, string>());
                }
                for (int i = 0; i < tokens.Count-1; i+=2)
                {
                    string key = tokens[i];
                    string value = tokens[i + 1];
                    if (!result[name].ContainsKey(key))
                    {
                        result[name].Add(key, "0");
                    }
                    result[name][key] = value;
                }
                
            }

            int targetInfoIndex = 0;
            foreach (var name in result)
            {
                if (name.Key == zapodozrqn)
                {
                    Console.WriteLine($"Info on {name.Key}:");
                    foreach (var info in name.Value.OrderBy(x => x.Key))
                    {
                        targetInfoIndex += info.Key.Length;
                        targetInfoIndex += info.Value.Length;
                        Console.WriteLine($"---{info.Key}: {info.Value}");
                    }
                    Console.WriteLine($"Info index: {targetInfoIndex}");
                    if (targetInfoIndex >= infoIndex)
                    {
                        Console.WriteLine("Proceed");
                    }
                    else
                    {
                        int diff = infoIndex - targetInfoIndex;
                        Console.WriteLine($"Need {diff} more info.");
                    }
                }               
            }
        }
    }
}
