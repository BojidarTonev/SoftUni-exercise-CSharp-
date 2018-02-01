using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowWhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> result = new Dictionary<string, Dictionary<string, long>>();
            List<string>numberOfInput = new List<string>();
            string input = Console.ReadLine();
            while (input != "Once upon a time")
            {
                string[] tokens = input.Split(new string[] { " <:> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = tokens[0];
                string hatColor = tokens[1];
                long physics = long.Parse(tokens[2]);
                if (!result.ContainsKey(hatColor))
                {
                    result.Add(hatColor, new Dictionary<string, long>());
                    result[hatColor].Add(name, physics);
                    numberOfInput.Add(hatColor);
                }
                else
                {
                    if (!result[hatColor].ContainsKey(name))
                    {
                        result[hatColor].Add(name, physics);
                    }
                    else
                    {
                        if (result[hatColor][name] < physics)
                        {
                            result[hatColor][name] = physics;
                        }
                    }
                }
                input = Console.ReadLine();
            }
            result = result.OrderByDescending(x => x.Value.Values.Max()).ThenByDescending(x=>x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var dwarf in result)
            {
                foreach (var item in dwarf.Value)
                {
                    Console.WriteLine($"({dwarf.Key}) {item.Key} <-> {item.Value}");
                }
            }
        }
    }
}