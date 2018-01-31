using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_evolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> result = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();

            while (input != "wubbalubbadubdub")
            {
                if (!input.Contains(" ") && input != "wubbalubbadubdub")
                {
                    foreach (var item in result)
                    {
                        if (item.Key == input)
                        {
                            Console.WriteLine($"# {item.Key}");
                            foreach (var value in item.Value)
                            {
                                Console.WriteLine($"{value.Key.Trim()} <-> {value.Value}");
                            }
                        }
                    }
                }
                else
                {
                    string[] tokens = input.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string pokemonName = tokens[0];
                    string evolutionType = tokens[1];
                    long evolutionIndex = long.Parse(tokens[2]);

                    if (!result.ContainsKey(pokemonName))
                    {
                        result.Add(pokemonName, new Dictionary<string, long>());
                        if (!result[pokemonName].ContainsKey(evolutionType))
                        {
                            result[pokemonName].Add(evolutionType, evolutionIndex);
                        }
                        else
                        {
                            result[pokemonName].Add(evolutionType+" ", evolutionIndex);
                        }
                    }
                    else
                    {
                        if (!result[pokemonName].ContainsKey(evolutionType))
                        {
                            result[pokemonName].Add(evolutionType, evolutionIndex);
                        }
                        else
                        {
                            result[pokemonName].Add(evolutionType+" ", evolutionIndex);
                        }
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var item in result)
            {
                Console.WriteLine($"# {item.Key}");
                foreach (var value in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{value.Key.Trim()} <-> {value.Value}");
                }
            }
        }
    }
}
